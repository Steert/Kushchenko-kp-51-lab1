namespace Lib;

public class Sorter
{
    
    public static Record[] BucketSort(Record[] array, SortStatistics stats)
    {
        int bsize = SearchMax(array, stats) / 5 + 1;

        ListNode[] buckets = new ListNode[bsize];

        for (int i = 0; i < array.Length; i++)
        {
            int index = array[i].resultSeconds / 5;
            
            InsertInCorrectPos(ref buckets[index], array[i], stats);
        }
        
        CopyToArray(array, buckets, stats);

        return array;
    }

    public static int SearchMax(Record[] array, SortStatistics stats)
    {
        int max = array[0].resultSeconds;

        for (int i = 0; i < array.Length; i++)
        {
            stats.AmountOfComparison++;
            stats.AmountOfIterations++;
            if (array[i].resultSeconds > max)
            {
                max = array[i].resultSeconds;
            }
        }

        return max;
    }

    public static ListNode InsertInCorrectPos(ref ListNode listNode, Record value, SortStatistics stats)
    {
        stats.AmountOfComparison++;
        if (listNode == null || listNode.val.resultSeconds > value.resultSeconds)
        {
            listNode = new ListNode(value, listNode);
            return listNode;
        }
        
        ListNode current = listNode;
        while (current.next != null)
        {
            stats.AmountOfComparison++;
            stats.AmountOfIterations++;
            if (current.next.val.resultSeconds > value.resultSeconds)
            {
                break;
            }
            current = current.next;
        }
        
        ListNode result = new ListNode(value);
        result.next = current.next;
        current.next = result;

        return result;
    }

    public static Record[] CopyToArray(Record[] array, ListNode[] buckets, SortStatistics stats)
    {
        int counter = 0;
        for (int i = 0; i < buckets.Length; i++)
        {
            ListNode current = buckets[i];

            while (current != null)
            {
                stats.AmountOfIterations++;
                array[counter++] = current.val;
                current = current.next;
            }
        }

        return array;
    }
}