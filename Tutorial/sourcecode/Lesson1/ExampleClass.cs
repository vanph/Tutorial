namespace Lesson1
{
   public class ExampleClass1
    {

        public dynamic exampleMethod(dynamic d)
        {
            dynamic local = "Local int variable";

            int two = 2;

            return d is int ? local : two;
        }
    }

    public class ExampleClass2
    {

        public dynamic exampleMethod(object o)
        {
            dynamic local = "Local test variable";

            return local;
        }
    }
}
