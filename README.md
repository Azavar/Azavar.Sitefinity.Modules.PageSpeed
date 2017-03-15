# Azavar.Sitefinity.Modules.PageSpeed
Custom Sitefinity module which utilizes Google's PageSpeed Insights api to analyze the content of site pages, then generates suggestions to make that page faster.


![alt text](https://s3.us-east-2.amazonaws.com/page-speed-module-github-images/menu.png "Menu")

# Notes

- This version is compiled against Sitefinity version 9.1.6110.0 but you can change the version by updating the project's referenced [Sitefinity nuget package](http://nuget.sitefinity.com/#/home)
- The backend views utilize styles from the newish Light theme so this likely wont render well within the legacy backend UI.
- Has not been tested on a multisite instance
- Requires a page speed insights [api key](https://developers.google.com/speed/docs/insights/v2/first-app) Enter the key in the advanced settings under Settings -> Advanced -> PageSpeed
