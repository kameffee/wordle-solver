using System.Linq;
using NUnit.Framework;

namespace Solver.Test;

public class WordInputTests
{
    private UserWordInput _userWordInput;

    private class TestWordProvider : IWordProvider
    {
        private string[] _words = new[]
        {
            "stamp",
        };

        public string[] All() => _words;

        public bool Exists(string word)
        {
            return _words.Any(s => s.Equals(word));
        }
    }

    [SetUp]
    public void Setup()
    {
        _userWordInput = new UserWordInput(new TestWordProvider(), new Logger());
    }

    [Test]
    [TestCase("s")]
    [TestCase("sss")]
    [TestCase("ssssss")]
    public void 入力チェック5文字以外で通らない(string word)
    {
        Assert.That(_userWordInput.Validate(word), Is.False);
    }
    
    [Test]
    [TestCase("stamp")]
    public void 入力チェック5文字で通る(string word)
    {
        Assert.That(_userWordInput.Validate(word), Is.True);
    }

    [Test]
    [TestCase("stamp")]
    public void 存在するワード(string word)
    {
        Assert.That(_userWordInput.Validate(word), Is.True);
    }
    
    [Test]
    [TestCase("value")]
    public void 存在しないワード(string word)
    {
        Assert.That(_userWordInput.Validate(word), Is.False);
    }
}
