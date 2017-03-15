[![Build status](https://ci.appveyor.com/api/projects/status/co4052awy3vd8l7q?svg=true)](https://ci.appveyor.com/project/azavar/azavar-sitefinity-modules-pagespeed)

# Azavar.Sitefinity.Modules.PageSpeed
Custom Sitefinity module which utilizes Google's PageSpeed Insights api to analyze the content of site pages, then generates suggestions to make that page faster.

## Menu
![alt text][menu]

## Audit Any Site 

![external-sites]

## Audit Your Own Site

![this-site]

## View Results

![results]

![results-expanded]

## View Details

![result-details]

## Notes

- This version is compiled against Sitefinity version 9.1.6110.0 but you can change the version by updating the project's referenced [Sitefinity nuget package](http://nuget.sitefinity.com/#/home)
- The backend views utilize styles from the newish Light theme so this likely wont render well within the legacy backend UI.
- Requires a page speed insights [api key](https://developers.google.com/speed/docs/insights/v2/first-app) Enter the key in the advanced settings under Settings -> Advanced -> PageSpeed
- Has not been tested on a multisite instance
- Has not been localized


[menu]: https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/menu-resize.png "Menu"
[external-sites]: https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/external-resize.png 
[this-site]: https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/this-site-resize.png
[results]: https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/results.png
[results-expanded]: https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/results-expanded.png
[result-details]: https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/results-details.png
