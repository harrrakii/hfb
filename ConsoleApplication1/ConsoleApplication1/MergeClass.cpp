#pragma once
#include <vector>
#include <thread>

class MergeSort {
public:
    void Sort(std::vector<int>& array) {
        if (array.size() <= 1) return;

        std::vector<int> left(array.begin(), array.begin() + array.size() / 2);
        std::vector<int> right(array.begin() + array.size() / 2, array.end());

        std::thread leftThread(&MergeSort::Sort, this, std::ref(left));
        std::thread rightThread(&MergeSort::Sort, this, std::ref(right));

        leftThread.join();
        rightThread.join();

        Merge(array, left, right);
    }

private:
    void Merge(std::vector<int>& array, const std::vector<int>& left, const std::vector<int>& right) {
        size_t i = 0, j = 0, k = 0;

        while (i < left.size() && j < right.size()) {
            if (left[i] <= right[j]) {
                array[k++] = left[i++];
            }
            else {
                array[k++] = right[j++];
            }
        }

        while (i < left.size()) {
            array[k++] = left[i++];
        }

        while (j < right.size()) {
            array[k++] = right[j++];
        }
    }
};
