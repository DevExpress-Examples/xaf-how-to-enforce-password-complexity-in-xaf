<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2849)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to enforce password complexity in XAF
This example shows how to validate passwords in XAF apps.

## Implementation Details

The easiest way to accomplish this task is to create a dedicated validation rule with [Model Editor](https://docs.devexpress.com/eXpressAppFramework/112582/concepts/application-model/model-editor) that cheks all new passwords with a regex expression.
For additional information, refer to the following help topic [Validate Password Complexity](https://docs.devexpress.com/eXpressAppFramework/401909/validation/validate-password-complexity)


## Files to Review

* [Model.DesignedDiffs.xafml](CS/EF/PasswordComplEF/PasswordComplEF.Module/Model.DesignedDiffs.xafml) 

## Documentation 

- [Validate Password Complexity](https://docs.devexpress.com/eXpressAppFramework/401909/validation/validate-password-complexity)


