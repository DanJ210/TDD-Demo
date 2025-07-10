# TDD Helper Scripts

# Run specific String Calculator tests
Write-Host "🧪 TDD Test Runner for String Calculator" -ForegroundColor Cyan
Write-Host "=======================================" -ForegroundColor Cyan

# Function to run a specific test
function Run-TDDTest {
    param(
        [string]$TestName,
        [string]$Description
    )
    
    Write-Host "`n🔍 Running: $Description" -ForegroundColor Yellow
    Write-Host "Test: $TestName" -ForegroundColor Gray
    Write-Host "---" -ForegroundColor Gray
    
    dotnet test --filter $TestName --verbosity normal
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✅ Test PASSED" -ForegroundColor Green
    } else {
        Write-Host "❌ Test FAILED" -ForegroundColor Red
    }
}

# Function to run all String Calculator tests
function Run-AllStringCalculatorTests {
    Write-Host "`n🔍 Running all String Calculator tests" -ForegroundColor Yellow
    Write-Host "---" -ForegroundColor Gray
    
    dotnet test --filter "StringCalculatorTests" --verbosity normal
    
    if ($LASTEXITCODE -eq 0) {
        Write-Host "✅ All tests PASSED" -ForegroundColor Green
    } else {
        Write-Host "❌ Some tests FAILED" -ForegroundColor Red
    }
}

# Menu
Write-Host "`nSelect an option:"
Write-Host "1. Run first test (Empty String)"
Write-Host "2. Run first two tests (Empty + Single Number)"
Write-Host "3. Run all String Calculator tests"
Write-Host "4. Run all project tests"
Write-Host "5. Exit"

$choice = Read-Host "`nEnter your choice (1-5)"

switch ($choice) {
    "1" { 
        Run-TDDTest "Add_EmptyString_ReturnsZero" "Empty string returns 0"
    }
    "2" { 
        dotnet test --filter "Add_EmptyString_ReturnsZero|Add_SingleNumber_ReturnsThatNumber" --verbosity normal
    }
    "3" { 
        Run-AllStringCalculatorTests
    }
    "4" { 
        Write-Host "`n🔍 Running all tests in the project" -ForegroundColor Yellow
        dotnet test --verbosity normal
    }
    "5" { 
        Write-Host "Goodbye! Happy TDD-ing! 🚀" -ForegroundColor Green
        exit
    }
    default { 
        Write-Host "Invalid choice. Please run the script again." -ForegroundColor Red
    }
}

Write-Host "`n🎯 TDD Tips:" -ForegroundColor Cyan
Write-Host "- Red: Write a failing test first" -ForegroundColor Red
Write-Host "- Green: Write minimal code to pass" -ForegroundColor Green
Write-Host "- Refactor: Improve code while keeping tests green" -ForegroundColor Blue
