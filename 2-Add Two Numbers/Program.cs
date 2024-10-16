// LinkedList can be up to 100 long
// Which means this can't be stored in an int or any other normal number class
// Gotta use BigInteger

using System.Numerics;

// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {

        static List<int> LinkedToList(ListNode input)
        {
            var listOutput = new List<int>();

            var item = input;
            while (item.next is not null)
            {
                listOutput.Add(item.val);
                item = item.next;
            }
            listOutput.Add(item.val);

            return listOutput;
        }

        var firstList = LinkedToList(l1);
        var secondList = LinkedToList(l2);

        static BigInteger ListToBigInt(List<int> input)
        {
            var listString = "";

            for (int i = input.Count - 1; i >= 0; i--)
            {
                listString += input[i].ToString();
            }

            BigInteger.TryParse(listString, out BigInteger intOutput);

            return intOutput;
        }

        var firstNumber = ListToBigInt(firstList);
        var secondNumber = ListToBigInt(secondList);

        var comboNumber = firstNumber + secondNumber;

        var comboString = comboNumber.ToString();

        var Output = new ListNode();
        var item = Output;
        for (int i = comboString.Count() - 1; i > 0; i--)
        {
            // Ugly, but needed to convert a char to its written value
            // Otherwise it converts the char to its unicode value
            item.val = (char)char.GetNumericValue(comboString[i]);
            item.next = new ListNode();
            item = item.next;
        }
        item.val = (char)char.GetNumericValue(comboString[0]);

        return Output;
    }


    static void Main(string[] args)
    {

        static ListNode CreateListNode(List<int> input)
        {
            var output = new ListNode();
            var item = output;
            for (int i = 0; i < input.Count - 1; i++)
            {
                item.val = input[i];
                item.next = new ListNode();
                item = item.next;
            }
            item.val = input[input.Count - 1];

            return output;
        }

        var list1 = new List<int>{1};
        var list2 = new List<int>{1,9,9,9,9,9,9,9,9,9};

        var l1 = CreateListNode(list1);
        var l2 = CreateListNode(list2);

        var final = new Solution();
        final.AddTwoNumbers(l1,l2);

    }
}

