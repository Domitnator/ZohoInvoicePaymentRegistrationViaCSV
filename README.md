# ZohoInvoicePaymentRegistrationViaCSV
A simple console application for registering invouice payment records based on a CSV file


## Get accesstoken

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