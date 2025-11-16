int num;
//Victor Victor Aybar 20250963 
Console.Write("Could you insert a number to determine if is even or not even \n");
num = Convert.ToInt32(Console.ReadLine());

if (num % 2 == 0)
{
    Console.WriteLine("The number that has been inserted is even");
}
else
{
    Console.WriteLine("The number that has been inserted is not even");
}
Console.ReadKey();
