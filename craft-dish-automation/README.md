## How it works

<img class="irc_mi" src="https://cdn2.hubspot.net/hubfs/429321/Blog/scenario.png?t=1468102832853" alt="Картинки по запросу appium" onload="typeof google==='object'&amp;&amp;google.aft&amp;&amp;google.aft(this)" style="margin-top: 0px;" width="465" height="353">

## Requirements
 - Java 1.8+
 - Appium npm package v1.8.1 (node.js)
 - Android SDK
 - IntelliJ IDEA Community Edition

## Note:

Install appium via node.js by command `npm install -g appium@1.8.1 `

## Local launch of tests for `android.xml`

1. Clone repo by `https://github.com/tasks-delivery/craft-dish.git`
2. Go to project dir by `cd craft-dish-automation`
1. Deploy appium server by command in node.js `appium -a localhost -p 4800 --relaxed-security`
2. mvn clean test -Dlang=`RU OR EN`



## Useful links

Selenide docs `http://selenide.org/`
Appium docs `http://appium.io/docs/en/about-appium/intro/`
Appium test examples in different languages `https://github.com/appium/sample-code/tree/master/sample-code/examples`


