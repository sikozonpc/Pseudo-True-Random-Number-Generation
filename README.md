# Pseudo-True-Random-Number-Generation
Breif explaination about how numbers are generated in a computer.

Well, it looks like a very simple theme, but most of the work in this process is handled by the method or class you are using , for instance, the "Random" class in C# uses something similar to what i am about to explain.

First thing let us understand the philosophy of RANDOMNESS. When we tell a person to choose a number between 1 and 10 what happens internally. What makes a person choose 3 or 8 or 10?

![alt text](https://i.stack.imgur.com/nsoQL.png)

Some initial thought goes into the persons mind which decides his choice. In other words some initial trigger which we term in RANDOM as *SEED*. This SEED is the beginning point, the trigger which instigates him to select the RANDOM value.

Now if a SEED is easy to guess then those kind of random numbers are termed as *PSEUDO* and when a seed is difficult to guess those random numbers are termed *SECURED* random numbers. 

![alt text](https://i.stack.imgur.com/vQ9y5.png)

*However, in C# the "Random" class generates only PSEUDO random numbers and to generate SECURE random numbers we use the "RNGCryptoServiceProvider" class*

![alt text](https://i.stack.imgur.com/JJ93T.png)

Random class takes seed values from your CPU clock which is very much predictable. So in other words RANDOM class of C# generates pseudo random numbers , below is the code for the same.
```
Random rnd= new Random();
int rndnumber = rnd.Next()
´´´
While the RNGCryptoServiceProvider class uses OS entropy to generate seeds. OS entropy is a random value which is generated using sound , mouse click and keyboard timings , thermal temp etc. Below goes the code for the same.
```
using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider()) 
{ 
  byte[] rno = new byte[5];    
  rg.GetBytes(rno);    
  int randomvalue = BitConverter.ToInt32(rno, 0); 
}
´´´
