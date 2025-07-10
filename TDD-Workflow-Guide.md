# TDD Workflow Guide - Step by Step

This guide demonstrates how to follow the Test-Driven Development process with the String Calculator example.

## 🎯 TDD Rules
1. **Red**: Write a failing test
2. **Green**: Write the minimum code to make it pass
3. **Refactor**: Improve the code while keeping tests green

## 📋 Step-by-Step Process

### Step 1: 🔴 RED - Write the First Failing Test

**Current Test:** `Add_EmptyString_ReturnsZero`

```bash
# Run the test (should fail)
dotnet test --filter "Add_EmptyString_ReturnsZero"
```

**Expected Result:** ❌ Test fails with `NotImplementedException`

---

### Step 2: 🟢 GREEN - Make the Test Pass

Replace the `Add` method in `StringCalculator.cs`:

```csharp
public int Add(string numbers)
{
    return 0; // Simplest implementation to pass the test
}
```

```bash
# Run the test again (should pass)
dotnet test --filter "Add_EmptyString_ReturnsZero"
```

**Expected Result:** ✅ Test passes

---

### Step 3: 🔵 REFACTOR - Improve Code (if needed)

- Code is simple, no refactoring needed yet
- All tests still green ✅

---

### Step 4: 🔴 RED - Next Test

Uncomment the next test in `StringCalculatorTests.cs`:

```csharp
[Fact]
public void Add_SingleNumber_ReturnsThatNumber()
{
    // Test implementation already provided
}
```

```bash
# Run both tests (new one should fail)
dotnet test --filter "StringCalculatorTests"
```

**Expected Result:** 
- ✅ `Add_EmptyString_ReturnsZero` passes
- ❌ `Add_SingleNumber_ReturnsThatNumber` fails

---

### Step 5: 🟢 GREEN - Make Both Tests Pass

Update the `Add` method:

```csharp
public int Add(string numbers)
{
    if (string.IsNullOrEmpty(numbers))
        return 0;
    
    return int.Parse(numbers);
}
```

```bash
# Run tests
dotnet test --filter "StringCalculatorTests"
```

**Expected Result:** ✅ Both tests pass

---

### Step 6: Continue the Cycle

Repeat this process for each test:

1. **Uncomment** the next test
2. **Run tests** (new test should fail) 🔴
3. **Write minimal code** to make it pass 🟢
4. **Refactor** if needed 🔵
5. **Run all tests** to ensure nothing broke
6. **Update TestList.md** to mark test as complete

---

## 🎓 Learning Points for Your Team

### Key TDD Principles:

1. **Baby Steps**: Each test should require minimal code changes
2. **Fail First**: Always see the test fail before making it pass
3. **Simplest Solution**: Don't over-engineer; write just enough code
4. **Refactor Safely**: Only refactor when all tests are green
5. **One Thing at a Time**: Focus on one failing test

### Common Mistakes to Avoid:

❌ Writing multiple tests at once
❌ Writing production code before tests
❌ Making tests too complex
❌ Skipping the refactor step
❌ Not running tests frequently

### Benefits of This Approach:

✅ **Confidence**: Every line of code is tested
✅ **Design**: Tests drive better API design
✅ **Documentation**: Tests serve as living documentation
✅ **Regression Protection**: Changes don't break existing functionality
✅ **Faster Development**: Less debugging time

---

## 🚀 Team Exercise Ideas

### Exercise 1: Complete the String Calculator
- Work in pairs
- Take turns being "driver" and "navigator"
- Follow the exact TDD cycle for each test
- Discuss refactoring opportunities

### Exercise 2: Add Your Own Requirements
- Add new test cases to the TestList.md
- Implement them using TDD
- Examples:
  - Support for decimal numbers
  - Different number formats (hex, binary)
  - Mathematical operations beyond addition

### Exercise 3: Code Review TDD Style
- Review each other's implementations
- Focus on test quality and coverage
- Discuss alternative implementations

---

## 📊 Tracking Progress

Update your TestList.md as you complete each test:

```markdown
### ✅ Completed Tests
- [x] Empty string returns 0
- [x] Single number returns that number
- [ ] Two comma-separated numbers return their sum
- [ ] Multiple comma-separated numbers return their sum
...
```

This visual progress helps the team stay focused and celebrates small wins!
