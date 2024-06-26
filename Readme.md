<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128590075/14.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2849)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Model.DesignedDiffs.xafml](./CS/Solution161.Module/Model.DesignedDiffs.xafml) (VB: [Model.DesignedDiffs.xafml](./VB/Solution161.Module/Model.DesignedDiffs.xafml))
* [Module.cs](./CS/Solution161.Module/Module.cs) (VB: [Module.vb](./VB/Solution161.Module/Module.vb))
* [Updater.cs](./CS/Solution161.Module/Updater.cs) (VB: [Updater.vb](./VB/Solution161.Module/Updater.vb))
<!-- default file list end -->
# How to enforce password complexity in XAF


<p>This task can be accomplished by validating user-entered passwords in the ChangePasswordOnLogonParameters and ChangePasswordParameters detail views. Here, we create a code rule to check password complexity using a custom function. This rule should be checked in a custom context, attached to the DialogOK action, because ChangePasswordOnLogonParameters is a non-persistent object, and the Save context is not appropriate for it.<br />
Also, we have to explicitly initialize the validation rule set, otherwise validation won't work prior to user login.</p><p>For additional information, refer to the <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3259"><u>Non Persistent Objects Validation</u></a> help topic.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-enforce-password-complexity-in-xaf&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-how-to-enforce-password-complexity-in-xaf&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
