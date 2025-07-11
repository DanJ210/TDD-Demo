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

## Two Schools
 1. Detroit School - Oldest (AKA. Classic)
    - Tend to write test verifictions first (action)
    - Then observe state or impact of action
    - Avoid test doubles until dependencies forces it (otherwise classical favors real implementation)
 2. London School (AKA Mockist "Mocking school")
    - Emphasizes collaboration and communication
    - Focuses on testing behavior rather than implementation
    - Encourages the use of test doubles (mocks, stubs) to isolate units of work
    - Starts with acceptance tests and breaks them down into smaller unit tests
    - What is an acceptance test?
      - A test that verifies the system meets business requirements
      - Often written in collaboration with stakeholders
      - Focuses on user stories and high-level functionality

-- **Key Differences**
   - Detroit School focuses on implementation details, while London School emphasizes behavior and collaboration
   - London School encourages the use of mocks and stubs to isolate units, while Detroit School prefers real implementations until necessary

-- **We Use Both as a Hybrid**
## TDD Best Practices
- **Red-Green-Refactor Cycle**: Always follow the cycle for each test
- **Arrange-Act-Assert Pattern**: Structure tests clearly
- **Single Responsibility**: Each test should focus on one behavior
- **Descriptive Test Names**: Use names that clearly describe the behavior being tested
- **Mock Dependencies**: Use Moq to isolate units under test
- **Test Edge Cases**: Include tests for boundary conditions and error scenarios
- **Verify Interactions**: Use Moq.Verify to ensure dependencies are called correctly

### Key TDD Principles:

1. **Test Names Matter**: Use descriptive names that explain the behavior - often drives the implementation
2. **Baby Steps**: Start Simple, each test should require minimal code changes
3. **Fail First**: Always see the test fail before making it pass
4. **Simplest Solution**: Don't over-engineer; write just enough code
5. **Refactor Safely**: Only refactor when all tests are green
6. **One Thing at a Time**: Focus on one failing test

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

## 📊 TDD in Agile Software Development

### TDD's Role in Agile Methodology

TDD naturally aligns with Agile principles and enhances team collaboration:

**Sprint Planning & User Stories**
- Break user stories into testable behaviors
- Use acceptance criteria to guide test creation
- Estimate complexity based on test scenarios

**Daily Standups**
- Discuss failing tests as blockers
- Share test progress as completion metrics
- Identify integration challenges early

**Sprint Reviews & Retrospectives**
- Demonstrate features through passing tests
- Review test coverage and quality metrics
- Discuss TDD adoption challenges and successes

### Continuous Integration Benefits

**Automated Testing Pipeline**
- Every commit triggers full test suite
- Fast feedback on code changes
- Prevents regression issues in shared codebase

**Code Quality Gates**
- Require minimum test coverage thresholds
- Block merges with failing tests
- Maintain consistent coding standards

### Team Collaboration Advantages

**Shared Understanding**
- Tests document expected behavior
- Clear definition of "done" for features
- Reduces miscommunication between team members

**Pair Programming Enhancement**
- Driver writes test, navigator suggests implementation
- Natural discussion points during red-green-refactor
- Knowledge sharing through test design

**Code Reviews Focus**
- Review test quality alongside implementation
- Verify test scenarios cover acceptance criteria
- Ensure tests are maintainable and readable

### Measuring TDD Success

**Key Metrics to Track**
- Test coverage percentage (aim for 80%+ on core logic)
- Test execution time (keep feedback loop fast)
- Defect escape rate (bugs found in production)
- Code complexity metrics (cyclomatic complexity)

**Team Velocity Indicators**
- Faster feature delivery after initial TDD adoption
- Reduced debugging and bug-fix time
- Increased confidence in refactoring and changes
