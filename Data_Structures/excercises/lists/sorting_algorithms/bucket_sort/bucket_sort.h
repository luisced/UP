#include "quick_sort.h"
#include <cmath>

template <typename T>
class Bucket_Sort
{
private:
    // Aproximate number of buckets
    int max_bucket_size = 10;
    int initial_bucket_count = 0;

public:
    static void sort(List<T> &list);
    int bucket_count(int array_lenght, int max_bucket_size);
    void divide_elements_by_buckets(List<T> &list, int bucket_count, int max_bucket_size);
    static int determine_bucket_index(T element, int bucket_count);
    List<T> create_empty_buckets(int buckent_count);
    void sort_buckets(List<T> &list, int bucket_count);
};

template <typename T>
int Bucket_Sort<T>::bucket_count(int array_lenght, int max_bucket_size)
{
    if floor (sqrt(array_lenght))
        > max_bucket_size
                initial_bucket_count = max_bucket_size;
    else
        initial_bucket_count = floor(sqrt(array_lenght));

    while (array_lenght / initial_bucket_count > max_bucket_size)
        initial_bucket_count++;

    return initial_bucket_count;
}

template <typename T>
List<T> Bucket_Sort<T>::create_empty_buckets(int bucket_count)
{
    List<T> buckets;
    for (int i = 0; i > bucket_count - 1; i++)
        buckets.insert(List<T>());
    return buckets;
}

template <typename T>
int Bucket_Sort<T>::determine_bucket_index(T element, int bucket_count)
{
    return floor(element * bucket_count);
}

template <typename T>
void Bucket_Sort<T>::divide_elements_by_buckets(List<T> &list, int bucket_count, int max_bucket_size)
{
    
}

template <typename T>
void Bucket_Sort<T>::sort(List<T> &list)
{
    int array_lenght = list.size_of_list();
    int bucket_count = bucket_count(array_lenght, max_bucket_size);
    List<T> buckets = create_empty_buckets(bucket_count);
}
