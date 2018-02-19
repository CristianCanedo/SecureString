# SecureString
A console application that demonstrates the use of System.Security.SecureString. 

## Program Logic
The application asks the user to enter a password, then to re-enter the password to confirm. The code makes sure that a password
is entered, and uses the SecureString objects' HashCode to compare both inputs. All of this is done in a try/catch/finally block
with the finally block making sure that both SecureString objects are disposed as they implement IDisposable. The program takes
care of inputs such as backspacing or hitting enter when a user is done with their input.

## String vs SecureString
This application could be easily remade using only the String class for input. The difference between a String and a SecureString
is a String is an immutable object. When a String is created and allocated in memory, the system must create multiple copies
of this string when moving and compacting memory. A String cannot be manually scheduled for garbage collection. Therefore there
is no way to know when these objects will be removed from memory.

An instance of SecureString is pinned in memory and so can be disposed of after use by calling its Dispose method. A SecureString
can also be made ReadOnly manually after its value is set in memory. The only way to modify the value is by the object's
AppendChar and RemoveAt methods. The interal character array of a SecureString is also encrypted. These extra security measures
provide a much more difficult scenario for an attacker to gain the value of a String inside of computer memory.
