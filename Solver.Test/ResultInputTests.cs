using NUnit.Framework;

namespace Solver;

/// <summary>
/// 試行結果入力
/// </summary>
public class ResultInputTests
{
    private UserResultInput _userResultInput = new UserResultInput(new Logger());

    [Test]
    [TestCase("00000")]
    public void 入力5文字で通る(string input)
    {
        Assert.That(_userResultInput.Validate(input), Is.True);
    }

    [Test]
    [TestCase("")]
    [TestCase("00")]
    [TestCase("000000")]
    public void 入力5文字以外は通らない(string input)
    {
        Assert.That(_userResultInput.Validate(input), Is.False);
    }

    [Test]
    [TestCase("00000")]
    [TestCase("11111")]
    [TestCase("00220")]
    public void 対応した数値のみ受け付ける(string input)
    {
        Assert.That(_userResultInput.Validate(input), Is.True);
    }
    
    [Test]
    [TestCase("31001")]
    [TestCase("00400")]
    [TestCase("00225")]
    public void 入力が012以外はエラー(string input)
    {
        Assert.That(_userResultInput.Validate(input), Is.False);
    }
}
