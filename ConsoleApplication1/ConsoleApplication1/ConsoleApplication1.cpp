#include <iostream>
#include <vector>
#include <thread>
#include "MergeClass.cpp"

int main() {
    using namespace std;
    locale::global(std::locale("Russian"));

    vector<int> array(10);
    cout << "Введите 10 целых чисел:" << endl;
    for (int i = 0; i < 10; ++i) {
        cout << "Введите число " << i + 1 << ": ";
        cin >> array[i];
    }

    MergeSort mergeSort;

    thread mergeSortThread([&mergeSort, &array]() {
        mergeSort.Sort(array);
        });

    mergeSortThread.join();

    cout << "Итоговый массив: ";
    for (const int& num : array) {
        cout << num << " ";
    }
    cout << endl;

    return 0;
}
