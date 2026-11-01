// MyList: an array that manages itself. It tracks the count, grows by
// doubling when it is full, and refuses any index that is not in use.
//
// Part B. Build this class along with the Class 1 demo.
// Insert is Exercise 2.
public class MyList<T>
{
    private T[] items;
    private int count;

    // Given. Every list starts with room for four items.
    public MyList()
    {
        items = new T[4];
        count = 0;
    }

    // TODO: Part B. How many slots are in use.
    public int Count => count;

    // TODO: Part B. How many slots exist (the array's Length).
    public int Capacity => items.Length;

    // Add to the end. Grow first if every slot is taken.
    public void Add(T item)
    {
        // TODO: Part B, demo
        if (count == items.Length)
        {
            Grow();
        }
        items[count] = item;
        count++;
    }
    //copies items to a new array double the original size
    private void Grow()
    {
        T[] bigger = new T[items.Length * 2];
        for (int i = 0; i < count; i++)
        {
            bigger[i] = items[i];
        }
        items = bigger;
    }
    //checks if the index is valid, throws exception if not
    private void CheckIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index));
        }
    }
    // The indexer is the code behind list[2]. Both get and set must
    // refuse any index that is not in use.
    public T this[int index]
    {
        get
        {
            // TODO: Part B, demo
            CheckIndex(index);
            return items[index];
        }
        set
        {
            // TODO: Part B, demo
            CheckIndex(index);
            items[index] = value;
        
        }
    }

    // Insert anywhere from 0 to Count. Inserting at Count is legal and
    // means the same thing as Add. Throw ArgumentOutOfRangeException
    // for anything else.
    public void Insert(int index, T item)
    {
        // TODO: Part B, Exercise 2
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(index));
        }
        if (count == items.Length)
        {
            Grow();
        }
        for (int i = count; i > index; i--)
        {
            items[i] = items[i - 1];
        }
        items[index] = item;
        count++;
    }

    // Remove the item at index and close the gap.
    public void RemoveAt(int index)
    {
        // TODO: Part B, demo
        CheckIndex(index);
        for (int i = index; i < count - 1; i++)
        {
            items[i] = items[i + 1];
        }
        count--;
    }

    // Linear search. Return the index, or -1 when the item is not there.
    // Compare with Equals(a, b), which works for every type T.
    public int IndexOf(T item)
    {
        // TODO: Part B, demo
        for (int i = 0; i < count; i++)
        {
            if (Equals(items[i], item))
            {
                return i;
            }
        }
        return -1;
    }

    // Given. Builds a line like "[A, B, C]" from the slots in use.
    public override string ToString()
    {
        string result = "[";
        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                result += ", ";
            }
            result += items[i];
        }
        return result + "]";
    }

    // TODO: Part B. Write two private helpers:
    //   Grow()            make a new array twice the size, copy every item
    //   CheckIndex(index) throw ArgumentOutOfRangeException unless
    //                     0 <= index < count
}