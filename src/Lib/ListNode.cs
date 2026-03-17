namespace Lib;

public class ListNode
{
    public Record val;
    public ListNode next;

    public ListNode(Record val = null, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}