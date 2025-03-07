
//for loop multiply a number by 5 and add it to total 
using System.Xml.Schema;

int xNumber = 1;
//int number = 1;
int total = 0;


for (int i = 0; i < 50; i++)
{
    xNumber = i * 5;
     total += xNumber;
    Console.WriteLine(total);
    //number += 1;
}