# COVID-19 Worldometers

```csharp
COVID19WorldometersController cOVID19WorldometersController = client.COVID19WorldometersController;
```

## Class Name

`COVID19WorldometersController`

## Methods

* [Global COVID-19 Totals](../../doc/controllers/covid-19-worldometers.md#global-covid-19-totals)
* [COVID-19 Totals for a Country](../../doc/controllers/covid-19-worldometers.md#covid-19-totals-for-a-country)
* [COVID-19 Totals for a Set of Countries](../../doc/controllers/covid-19-worldometers.md#covid-19-totals-for-a-set-of-countries)


# Global COVID-19 Totals

Get global COVID-19 totals for today, yesterday and two days ago

```csharp
GlobalCOVID19TotalsAsync(
    string yesterday = "false",
    string twoDaysAgo = "false",
    string allowNull = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `yesterday` | `string` | Query, Optional | Queries data reported a day ago<br>**Default**: `"false"` |
| `twoDaysAgo` | `string` | Query, Optional | Queries data reported two days ago<br>**Default**: `"false"` |
| `allowNull` | `string` | Query, Optional | By default, if a value is missing, it is returned as 0. This allows nulls to be returned |

## Response Type

[`Task<Models.CovidAll>`](../../doc/models/covid-all.md)

## Example Usage

```csharp
string yesterday = "false";
string twoDaysAgo = "false";

try
{
    CovidAll result = await cOVID19WorldometersController.GlobalCOVID19TotalsAsync(yesterday, twoDaysAgo, null);
}
catch (ApiException e){};
```


# COVID-19 Totals for a Country

Get COVID-19 totals for a specific country

```csharp
COVID19TotalsForACountryAsync(
    string country,
    string yesterday = "false",
    string twoDaysAgo = "false",
    string strict = null,
    string allowNull = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `country` | `string` | Template, Required | A country name, iso2, iso3, or country ID code |
| `yesterday` | `string` | Query, Optional | Queries data reported a day ago<br>**Default**: `"false"` |
| `twoDaysAgo` | `string` | Query, Optional | Queries data reported two days ago<br>**Default**: `"false"` |
| `strict` | `string` | Query, Optional | Setting to false gives you the ability to fuzzy search countries (i.e. Oman vs. rOMANia) |
| `allowNull` | `string` | Query, Optional | By default, if a value is missing, it is returned as 0. This allows nulls to be returned |

## Response Type

[`Task<Models.CovidCountry>`](../../doc/models/covid-country.md)

## Example Usage

```csharp
string country = "Pakistan";
string yesterday = "false";
string twoDaysAgo = "false";

try
{
    CovidCountry result = await cOVID19WorldometersController.COVID19TotalsForACountryAsync(country, yesterday, twoDaysAgo, null, null);
}
catch (ApiException e){};
```


# COVID-19 Totals for a Set of Countries

Get COVID-19 totals for a specific set of countries

```csharp
COVID19TotalsForASetOfCountriesAsync(
    string countries,
    string yesterday = "false",
    string twoDaysAgo = "false",
    string allowNull = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `countries` | `string` | Template, Required | Multiple country names, iso2, iso3, or country IDs separated by commas |
| `yesterday` | `string` | Query, Optional | Queries data reported a day ago<br>**Default**: `"false"` |
| `twoDaysAgo` | `string` | Query, Optional | Queries data reported two days ago<br>**Default**: `"false"` |
| `allowNull` | `string` | Query, Optional | By default, if a value is missing, it is returned as 0. This allows nulls to be returned |

## Response Type

[`Task<List<Models.CovidCountry>>`](../../doc/models/covid-country.md)

## Example Usage

```csharp
string countries = "Pakistan, China";
string yesterday = "false";
string twoDaysAgo = "false";

try
{
    List<CovidCountry> result = await cOVID19WorldometersController.COVID19TotalsForASetOfCountriesAsync(countries, yesterday, twoDaysAgo, null);
}
catch (ApiException e){};
```

