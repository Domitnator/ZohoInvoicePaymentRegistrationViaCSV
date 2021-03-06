# ZohoInvoicePaymentRegistrationViaCSV
A simple application for registering invoice payment records based on a Knab transactions CSV file.

# To run this application

1. Fill in the properties in the appsettings.json
    - AccessToken: The accesstoken (see: Getting an accesstoken)
    - CustomerId: the zoho customerId for which the payments should be created
    - TransactionsFile: The path to the knab banking transactions file
    - OutputFile: The path used for creating a output file (so you can see the log)

# Limitations
- The extraction of the invoice number from the banking-transactions is hardcoded. It expects a invoicenumber in the form of "INV-20210001" or "20210001"
- PaymentMode is hardcoded to "banktransfer"
- Payment description is hardcoded to "Betaling ontvangen voor factuur {output.InvoiceNumber}"

## Getting an accesstoken

1. Go to: https://api-console.zoho.com/
2. Create a "Self client"
3. Go to "Generate code" and use te following scope's to create a code

```
ZohoInvoice.fullaccess.all,ZohoInvoice.customerpayments.CREATE
```

4. Make a post:

```
curl --location --request POST 'https://accounts.zoho.com/oauth/v2/token' \
--form 'client_id="XXXXXXX"' \
--form 'client_secret="XXXXXXX"' \
--form 'grant_type="authorization_code"' \
--form 'code="XXXXXX"' \
--form 'expiry_time="1614935642077"'
```

5. This will give a response like this:

```
{
    "access_token": "XXXXXXXXXXX",
    "refresh_token": "XXXXXXXXXX",
    "api_domain": "https://www.zohoapis.com",
    "token_type": "Bearer",
    "expires_in": 3600
}
```

6. Use the access_token for subsequent requests:

```
curl --location --request GET 'https://invoice.zoho.com/api/v3/invoices' \
--header 'Authorization: Zoho-oauthtoken XXXXXXXXXXX' \
```