using System.Data.SqlTypes;

void show_arr(int[] arr)
{
    for (int i=0;i<arr.Length;i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}

int [] sort1 (int[] mas)
{
    int temp;
    for (int i = 0; i < mas.Length; i++)
    {
        for (int j = i + 1; j < mas.Length; j++)
        {
            if (mas[i] > mas[j])
            {
                temp = mas[i];
                mas[i] = mas[j];
                mas[j] = temp;
            }
        }
    }
    return mas;
}

List<int[]> _sort2(List<int[]> arrs)
{
    List<int[]> arrs1 = new List<int[]>();
    for (int i=0;i<arrs.Count;i=i+2)
    {
        if (i == arrs.Count - 1)
        {
            arrs1.Add(arrs[i]);
        }
        else
        {
            arrs1.Add(sliyanie(arrs[i], arrs[i + 1]));
        }
    }
    return arrs1;
}

int[] sliyanie (int[]mas1, int[]mas2)
{
    int[] mas = new int[mas1.Length + mas2.Length];
    int u1 = 0, u2 = 0;
    for (int i = 0; i < mas.Length;i++)
    {
        if (u2==mas2.Length)
        {
            for (int j=u1;j<mas1.Length;j++)
            {
                mas[i] = mas1[j];
                i++;
            }
            break;
        }
        if (u1 == mas1.Length)
        {
            for (int j = u2; j < mas2.Length; j++)
            {
                mas[i] = mas2[j];
                i++;
            }
            break;
        }
        if (mas1[u1] < mas2[u2])
        {
            mas[i] = mas1[u1];
            u1++;
        }
        else
        {
            mas[i] = mas2[u2];
            u2++;
        }
    }

    return mas;
}

int[] sort2(int[] arr)
{
    List<int[]> t = new List<int[]>();
    for (int i = 0; i < arr.Length; i++)
    {
        int[] tarr = new int[1];
        tarr[0] = arr[i];
        t.Add(tarr);
    }

    while (t.Count > 1)
    {
        t = _sort2(t);
    }

    for (int i=0;i<arr.Length;i++)
    {
        arr[i] = t[0][i];
    }
    return arr;

}





StreamWriter print = new StreamWriter
    ("C:\\Users\\Настя\\source\\repos\\sortirovki\\sortirovki\\Results.txt", true);

for (int j = 0; j < 10; j++)
{
    int n = 100000;
    int[] arr1 = new int[n];
    int[] arr2 = new int[n];
    Random rnd = new Random();
    for (int i = 0; i < n; i++)
    {
        int K = rnd.Next() % 100;
        arr1[i] = K;
        arr2[i] = K;
    }
    DateTime _begin = DateTime.Now;
    sort1(arr1);
    DateTime _end = DateTime.Now;
    print.Write("buble " + (_end - _begin).TotalSeconds + " ");
    _begin = DateTime.Now;
    sort2(arr2);
    _end = DateTime.Now;
    print.Write("sliyanie " + (_end - _begin).TotalSeconds + " ");
    print.WriteLine();

}

print.Close();