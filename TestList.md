# TDD Test List - String Calculator Kata

This document demonstrates the Test-Driven Development (TDD) approach using the classic "String Calculator" kata. We'll build features incrementally, following the **Red-Green-Refactor** cycle.

## 🎯 Requirements
Create a `StringCalculator` class with a method `Add(string numbers)` that:
1. Takes a string of comma-separated numbers and returns their sum
2. Handles edge cases and various input formats
3. Provides meaningful error messages

## 📋 Test List (What we need to test)

### ✅ Completed Tests
- [ ] Empty string returns 0
- [ ] Single number returns that number
- [ ] Two comma-separated numbers return their sum
- [ ] Multiple comma-separated numbers return their sum
- [ ] Handle newlines as delimiters (in addition to commas)
- [ ] Support custom delimiters (e.g., "//;\n1;2" returns 3)
- [ ] Negative numbers throw exception with message "negatives not allowed: [negative numbers]"
- [ ] Numbers bigger than 1000 are ignored
- [ ] Custom delimiters can be any length
- [ ] Multiple custom delimiters support

### 🔄 Current Focus
**Next Test:** Empty string returns 0

### 📝 Notes
- Each test should be small and focused on one behavior
- Follow Red-Green-Refactor cycle for each test
- Refactor only when tests are green
- Add tests to the "Completed" section as you finish them

---

## 🔄 TDD Workflow Example

### Step 1: Red Phase
Write a failing test for the first requirement:

```csharp
[Fact]
public void Add_EmptyString_ReturnsZero()
{
    // Arrange
    var calculator = new StringCalculator();
    
    // Act
    int result = calculator.Add("");
    
    // Assert
    Assert.Equal(0, result);
}
```

**Expected Result:** ❌ Test fails (StringCalculator class doesn't exist)

### Step 2: Green Phase
Write the minimal code to make the test pass:

```csharp
public class StringCalculator
{
    public int Add(string numbers)
    {
        return 0; // Simplest implementation to pass the test
    }
}
```

**Expected Result:** ✅ Test passes

### Step 3: Refactor Phase
- Code is simple, no refactoring needed yet
- Move to next test

### Step 4: Repeat for Next Test
Continue this cycle for each item in the test list...

---

## 🎓 TDD Learning Points for Team

1. **Start Simple:** Begin with the simplest possible test case
2. **One Test at a Time:** Focus on making one test pass before moving to the next
3. **Minimal Implementation:** Write just enough code to make the test pass
4. **Refactor Safely:** Only refactor when all tests are green
5. **Test Names Matter:** Use descriptive names that explain the behavior
6. **Document Progress:** Check off completed tests to track progress

---

## 📚 References
- [String Calculator Kata](http://osherove.com/tdd-kata-1/)
- [TDD Best Practices](https://docs.microsoft.com/en-us/dotnet/core/testing/best-practices)
