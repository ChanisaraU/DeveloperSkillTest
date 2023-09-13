using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using Challenge.Service;

namespace Challenge.Test;

public class Tests
{
    private dynamic _data;
    [SetUp]
    public void Setup()
    {
        using (StreamReader r = new StreamReader(Path.Combine(TestContext.CurrentContext.TestDirectory, "data.json")))
        {
            string json = r.ReadToEnd();
            _data = JsonConvert.DeserializeObject(json) ?? Array.Empty<int>();
        }
    }

    [Test]
    public void Test_All_Passed()
    {
        foreach (var testCase in _data)
        {
            int m = testCase.m;
            List<int> arr = testCase.arr.ToObject<List<int>>();
            List<int> expected = testCase.expected.ToObject<List<int>>();
            List<int> result = App.MenusFromBudget(m, arr);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}