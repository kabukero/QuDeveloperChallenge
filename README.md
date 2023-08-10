# QuDeveloperChallenge

Qu developer challenge: Word Finder

## Pre-requisites

- .NET 6.0 Framework

## How to run the bechmarking test

Run the BenchmarkingTestingApp in Release Mode

## Bechmarking test analysis and evaluation

![alt text](https://github.com/kabukero/QuDeveloperChallenge/blob/main/BenchmarkingTestingApp/img/2023-08-09%2021_32_30-1_1%20Remaining.png)

- Benchmarking test takes 7 sec
- Wordfinder.CountWords(...) method has O(N^2) Time Complexity
- Wordfinder.UpdateOccurrencesMap(...) method has O(1) Time Complexity
- Wordfinder.OrderOccurrencesMap(...) method has O(N Log N) Time Complexity