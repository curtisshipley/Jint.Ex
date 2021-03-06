﻿using System;
using Jint.Ex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace JintEx_UnitTests
{
    [TestClass]
    public class SetTimeOut_SetInterval_UnitTests
    {
        private AsyncronousEngine ae;

        private AsyncronousEngine GetNewAsyncronousEngine()
        {
            ae = new AsyncronousEngine();
            ae.EmbedScriptAssemblies.Add(Assembly.GetExecutingAssembly());
            return ae;
        }
        private object GetJSVariable(string name)
        {
            var v = Jint.Ex.HelperClass.ConvertJsValueToNetValue(ae.Engine.Execute(name).GetCompletionValue());
            return v;
        }
        
        [TestMethod]
        public void setIntervalSetTimeoutNested()
        {            
            GetNewAsyncronousEngine().RequestFileExecution("setIntervalSetTimeoutNested.js", true);
            Assert.AreEqual(8.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void setTimeoutNestedNested()
        {
            GetNewAsyncronousEngine().RequestFileExecution("SetTimeoutNestedNested.js", true);
            Assert.AreEqual(3.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void setTimeoutNested()
        {
            GetNewAsyncronousEngine().RequestFileExecution("SetTimeoutNested.js", true);
            Assert.AreEqual(2.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void setTimeout_1()
        {
            GetNewAsyncronousEngine().RequestFileExecution("setTimeout.1.js", true);
            Assert.AreEqual(1.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void setTimeout_3()
        {
            GetNewAsyncronousEngine().RequestFileExecution("setTimeout.3.js", true);
            Assert.AreEqual(2.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void clearTimeout()
        {
            GetNewAsyncronousEngine().RequestFileExecution("clearTimeout.js", true);
            Assert.AreEqual(0.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void setInterval()
        {
            GetNewAsyncronousEngine().RequestFileExecution("setInterval.js", true);
            Assert.AreEqual(4.0, GetJSVariable("counter"));
        }

        [TestMethod]
        public void clearInterval()
        {
            GetNewAsyncronousEngine().RequestFileExecution("clearInterval.js", true);
            Assert.AreEqual(0.0, GetJSVariable("counter"));
        }
    }
}
