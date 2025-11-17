# Couriers.Speedex

## Basic Usage

The client uses the Result pattern, so there is not need for try-catch blocks. 
All the client methods, return an IHttpRequestResult, as the return type, instead of throwing exceptions. 
The result instance contains the possible result of the method, along with the HTTP request payload text and response text. 
In case of any error, the property ErrorMessage can be used to identify the possible error. 
The current implementation is based on the version <b>1.8</b> version of the Speedex API.

```csharp
var username = "demoapi";

var password = "GOOD-GO-HOME-GUYS";

var agreementCode = "002";

var customerCode = "DEMO";

var speedexCredentials = new SpeedexCredentials(username, password, agreementCode, customerCode);

using var speedexClient = new SpeedexClient(speedexCredentials);

// Use the details for your consignment
var consignment = new ConsignmentRequestModel(.......);

var createVoucherResponse = await speedexClient.CreateConsignmentAsync(consignment, cancellationToken);

if(!createVoucherResponse.IsSuccessful)
{
	var errorMessage = createVoucherResponse.ErrorMessage;

	var requestPayload = createVoucherResponse.RequestPayload;

	var responsePayload = createVoucherResponse.ResponsePayload;

	// Handle the scenario when an error occurs
	throw new InvalidOperationException(errorMessage);
}

var voucher = createVoucherResponse.Result.VoucherId;
```

## Dependency Injection

To add the SpeedexClient implementation to your Dependency Injection container, you can use the following extension methods:

```cs
var credentials = new SpeedexCredentials(….);

// For the production environment
services.AddSpeedexClient(credentials);

// For the demo environment
services.AddDemoSpeedexClient(credentials);
```

The services are registered and the ISpeedexClient interface, with Scoped lifetime. 
You also can add multiple implementations for the ISpeedexClient interface. 
Starting from the version 4.0.0 of the package, that targets .Net 8 and greater, you can also specify a key for each registered implementation. 
If you do so, then the implementation is also added as a Keyed Service with the key you specified. 

Example:

```cs
var credentials = new SpeedexCredentials(….);

services.AddSpeedexClient(credentials, “key”);

services.AddSpeedexClient(credentials, “key2”);

public class SomeClass([FromKeyedServices("key")] ISpeedexClient client)
{

}
public class AnotherClass([FromKeyedServices("key2")] ISpeedexClient client)
{

}
public class SomeOtherClass(IEnumerable<ISpeedexClient> clients)
{

}
```


## Client Method to Web Method Mapping

| Client Method | Web Method |
| :------------- | :------- |
| CreateSessionAsync | CreateSession |
| CancelConsignmentByVoucherIdAsync | CancelBOL |
| CreateConsignmentsAsync and CreateConsignmentAsync | CreateBOL |
| GetConsignmentPdfsAsync and GetConsignmentPdfAsync | GetBOLPdf |
| GetBranchesAsync | GetBranches |
| GetLastCheckPointAsync | GetLastCheckpoint |
| GetLastPickupCheckPointAsync | GetOrderLastCheckpoint |
| GetTraceByClientReferencesAsync | GetTraceByClientKey |
| GetTraceByTimeFrameAsync | GetTraceByDate |
| GetTraceByVoucherIdAsync | GetTraceByVoucher |
| CancelPickupByIdAsync | CancelPickup |
| CreatePickupAsync | CreatePickup |
| GetConsignmentsByDateRangeAsync | GetConsignmentsByDate |
| GetDepositedConsignmentsByDateRangeAsync | GetDepositedConsignmentsByDate |
| GetPickupByIdAsync | GetPickup |
| ReschedulePickupAsync | ReschedulePickup |

## Breaking Changes 

- Upgrading from <b>1.x.x</b> version to <b>2.x.x</b> or greater:
The new CLR types DateOnly and TimeOnly where used, in place of DateTime, where appropriate.
To convert from DateOnly and TimeOnly to DateTime and backwards, you can use the following conversions:

```cs
var dateTime = DateTime.Now;

var timeOnly = TimeOnly.FromDateTime(dateTime);

var dateOnly = DateOnly.FromDateTime(dateTime);

dateTime = new DateTime(dateOnly, timeOnly);
```

## Release Notes

- Version 1.0.0: Initial release.
- Version 2.0.0: Upgrade to .Net 6. Also, the new CLR types DateOnly and TimeOnly where used, in place of DateTime, where appropriate.
- Version 3.0.0: Upgrade to .Net 7. Along with constructors, object initialization support was added.
- Version 4.0.0: Upgrade to .Net 8. Reduced memory impact be using the collection expressions.
- Version 5.0.0: Upgrade to .Net 9.
- Version 6.0.0: Upgrade to .Net 10.