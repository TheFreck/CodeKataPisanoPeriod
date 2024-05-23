# CodeKataPisanoPeriod

https://www.codewars.com/kata/65de16794ccda6356de32bfa/train/csharp

Well known Fibonacci sequence have interesting property - if you take every Fibonacci number modulo n, eventually they will form cycle. For example, if n = 5, {F_k mod 5} is
<pre>
0, 1, 1, 2, 3, 0, 3, 3, 1, 4, 0, 4, 4, 3, 2, 0, 2, 2, 4, 1, 0, 1, ... 
</pre>
Length of this cycle called Pisano period. You can read more about it properties on Wiki and here.

Your task is to calculate Pisano period for given number n.

Size of numbers will not exceed 64 bits. Note, that naive approach will definitely fail on this one. There is also easier version of same task.
