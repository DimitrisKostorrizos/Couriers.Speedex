# Couriers.Speedex

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

	throw new InvalidOperationException(errorMessage);
}

var voucher = createVoucherResponse.Result.VoucherId;
```