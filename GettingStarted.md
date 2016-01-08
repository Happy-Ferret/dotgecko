

# Introduction #

**dotGecko** is .NET wrapper of the Mozilla [XULRunner](https://developer.mozilla.org/en/xulrunner), implemented with C#, using PInvoke and COM Interop.

**dotGecko** consists of three assemblies:
  * `DotGecko.Gecko.Interop`
> assembly contains declarations of XPCOM interfaces, structures, XPCOM API functions, constants, etc., needed for low-level work with XULRunner;
  * `DotGecko.Gecko`
> assembly contains high-level wrappers of Gecko (XULRunner) objects: browser, DOM, services, factories, streams, etc.;
  * `DotGecko.Controls`
> assembly contains WindowsForms and WPF controls, that enable Gecko-browser to be embedded into your application;

# Preparation #

The only thing you have to do before starting work with **dotGecko** - install XULRunner.

You can download the latest version of XULRunner from [releases.mozilla.org](http://releases.mozilla.org/pub/mozilla.org/xulrunner/releases/) or from [FTP](ftp://ftp.mozilla.org/pub/xulrunner/releases/). If you want to extend **dotGecko** capabilities, then you need to download XULRunner SDK too.

If you already have installed applications that use XULRunner runtime, for example Firefox or Thunderbird, then you can use this application's runtime.

# dotGecko - sample #

This section will explain how to use **dotGecko** by simple sample.

## Step 1. Initialization ##
