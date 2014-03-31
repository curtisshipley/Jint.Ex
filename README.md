﻿# Jint.Ex

## Overview

Jint.Ex is a C# library adding new features to the JavaScript runtime ***[Jint](https://github.com/sebastienros/jint)***.
The main goal is to be able to integrate Jint with UI SDK like 

1. .NET WinForm in Windows
2. UIKit SDK on iOS with the Xamarin stack 
3. Android too with Xamarin stack
4. WinPhone

Integrating with these UI SDKs (1 and 2 are my primary goals) requires the following:

* Building non blocking UI
    * Script are executed in a background thread with ability to access UI (forms and controls)
* Abililty to build true asynchronous API
* Ability to call setTimeout() and setInterval()

Though Jint.Ex will use only 1 .NET background Thread and multiple Timers, 
only one piece of JavaScript will be executed at the same time.

## Phase

1.  Implement: setTimeout(), clearTimeOut(), setInterval() and clearInterval()

2.  Implement: Integration with WinForm

3.  Implement: Integration with iOS

## features

### setTimeout clearTimeOut

The methods setTimeout() and clearTimeOut() are not part of the JavaScript language,
but part of the DOM. Nevertheless they can be usefull and sometime necessary
to run some JavaScript libraries written for the browser.
These methods are also present in NodeJs.

We need them for Jint.

```javascript
function f3() {
    print('Hi 3');
}
var timeout3 = setTimeout(f3, 3000);
print(timeout3);
    
function f1() {
    print('Hi 1');
}
var timeout1 = setTimeout(f1, 1000);
print(timeout1);

clearTimeout(timeout3);
print('timeout3 cleared');
```

### setInterval clearInterval

