def binary_search(list, item):
    low = 0
    high = len(list) - 1

    while low <= high:
        mid = low + (high - low) // 2

        if list[mid] == item:
            return mid
        if list[mid] > item:
            high = mid - 1
        else:
            low = mid + 1

    return -1

#       0  1  2  3  4  5   6   7   8   9   10
list = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21]

print(binary_search(list, 13))
