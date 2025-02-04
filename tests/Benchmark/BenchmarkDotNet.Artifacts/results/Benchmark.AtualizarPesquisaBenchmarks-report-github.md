```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3037)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                      | Mean     | Error     | StdDev    | Median   | Gen0     | Gen1     | Allocated |
|---------------------------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|
| AtualizarPesquisa           | 2.125 ms | 0.0601 ms | 0.1735 ms | 2.096 ms | 250.0000 | 109.3750 |   1.52 MB |
| AtualizarPesquisaImperativa | 2.176 ms | 0.1114 ms | 0.3141 ms | 2.086 ms | 250.0000 | 109.3750 |   1.52 MB |
