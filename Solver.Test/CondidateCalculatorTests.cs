using System.Linq;
using NUnit.Framework;

namespace Solver.Test;

/// <summary>
/// 候補計算のテスト
/// </summary>
public class CondidateCalculatorTests
{
    private CandidateCalculator _calculator;

    [OneTimeSetUp]
    public void Setup()
    {
        var loader = new WordLoader("../../../../Solver/word_list.txt");
        _calculator = new CandidateCalculator(new WordDictionary(loader), new SilentLogger());
    }

    [Test]
    public void 全部確定の絞り込み()
    {
        var conditionData = new ConditionData();
        conditionData.Add(new WordResult("stamp", "22222"));

        Assert.That(_calculator.Calculate(conditionData)[0], Is.EqualTo("stamp"));
    }

    [Test]
    public void 一部確定の絞り込み()
    {
        var conditionData = new ConditionData();
        conditionData.Add(new WordResult("stamp", "22000"));

        Assert.That(_calculator.Calculate(conditionData), Has.All.StartsWith("st"));
    }

    [Test]
    public void 全部並びが違う時の絞り込み()
    {
        var conditionData = new ConditionData();
        conditionData.Add(new WordResult("pmtas", "11111"));

        Assert.That(_calculator.Calculate(conditionData)[0], Is.EqualTo("stamp"));
    }

    [Test]
    public void 黒になった文字は全ての箇所に含まれない()
    {
        var conditionData = new ConditionData();
        conditionData.Add(new WordResult("stamp", "00000"));

        var candidateWords = _calculator.Calculate(conditionData);

        Assert.That(candidateWords, Does.Not.Contain("s")
            .And.Not.Contain("t")
            .And.Not.Contain("a")
            .And.Not.Contain("m")
            .And.Not.Contain("p"));
    }

    [Test]
    public void 一度黄色になったところはその文字ではない()
    {
        var conditionData = new ConditionData();
        conditionData.Add(new WordResult("stamp", "10000"));

        var candidateWords = _calculator.Calculate(conditionData);

        // すべてのワードがsで始まらない
        Assert.That(candidateWords, Has.All.Not.StartsWith("s"));
    }

    [Test]
    public void すでにCorrectになっている文字がNotになった時()
    {
        var conditionData = new ConditionData();
        conditionData.Add(new WordResult("arise", "01001"));
        conditionData.Add(new WordResult("right", "10000"));
        conditionData.Add(new WordResult("defer", "02001"));

        var candidateWords = _calculator.Calculate(conditionData);

        // すべてのワードがsで始まらない
        Assert.That(candidateWords, Has.Some.EqualTo("perky"));
    }
}
