namespace Stirnreihe.Data;

public class LineOfPeople
{
    public Node? Head { get; set; } = null;

    public void AddToFront(Person person)
    {
        var newNode = new Node(person, Head);
        Head = newNode;
    }

    public void Clear()
    {
        Head = null;
    }

    public int AddSorted(Person person)
    {
        var newNode = new Node(person);
        if (Head == null || Head.Person.Height > newNode.Person.Height)
        {
            newNode.Next = Head;
            Head = newNode;
            return 0;
        }
        else
        {
            var current = Head;
            var index = 0;

            while (current.Next != null && current.Next.Person.Height <= newNode.Person.Height)
            {
                current = current.Next;
                index++;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            return index + 1;
        }
    }

    public Person RemovePersonAt(int index)
    {
        if (Head == null || index < 0)
        {
            throw new InvalidOperationException("Index out of bounds or list is empty.");
        }

        if (index == 0)
        {
            var toRemove = Head.Person;
            Head = Head.Next;
            return toRemove;
        }

        var current = Head;
        var currentIndex = 0;
        while (currentIndex < index - 1 && current.Next != null)
        {
            current = current.Next;
            currentIndex++;
        }

        if (current.Next == null)
        {
            throw new InvalidOperationException("Index out of bounds.");
        }

        var removedPerson = current.Next.Person;
        current.Next = current.Next.Next;
        return removedPerson;
    }

    public void Sort()
    {
        if (Head == null || Head.Next == null) { return; }

        bool swapped;
        do
        {
            swapped = false;
            var current = Head;
            Node? prev = null;

            while (current.Next != null)
            {
                if (current.Person.Height > current.Next.Person.Height)
                {
                    swapped = true;

                    Node temp = current.Next;
                    current.Next = temp.Next;
                    temp.Next = current;

                    if (prev == null) { Head = temp; }
                    else { prev.Next = temp; }

                    prev = temp;
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            }
        }
        while (swapped);
    }
}
