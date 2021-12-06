from collections import Counter
"""
Initial state: 3,4,3,1,2
After  1 day:  2,3,2,0,1
After  2 days: 1,2,1,6,0,8
After  3 days: 0,1,0,5,6,7,8
After  4 days: 6,0,6,4,5,6,7,8,8
After  5 days: 5,6,5,3,4,5,6,7,7,8
After  6 days: 4,5,4,2,3,4,5,6,6,7
After  7 days: 3,4,3,1,2,3,4,5,5,6
After  8 days: 2,3,2,0,1,2,3,4,4,5
After  9 days: 1,2,1,6,0,1,2,3,3,4,8
After 10 days: 0,1,0,5,6,0,1,2,2,3,7,8
After 11 days: 6,0,6,4,5,6,0,1,1,2,6,7,8,8,8
After 12 days: 5,6,5,3,4,5,6,0,0,1,5,6,7,7,7,8,8
After 13 days: 4,5,4,2,3,4,5,6,6,0,4,5,6,6,6,7,7,8,8
After 14 days: 3,4,3,1,2,3,4,5,5,6,3,4,5,5,5,6,6,7,7,8
After 15 days: 2,3,2,0,1,2,3,4,4,5,2,3,4,4,4,5,5,6,6,7
After 16 days: 1,2,1,6,0,1,2,3,3,4,1,2,3,3,3,4,4,5,5,6,8
After 17 days: 0,1,0,5,6,0,1,2,2,3,0,1,2,2,2,3,3,4,4,5,7,8
After 18 days: 6,0,6,4,5,6,0,1,1,2,6,0,1,1,1,2,2,3,3,4,6,7,8,8,8,8
"""
def solution1(lines, rem_days):
    lines = [int(i) for i in lines]
    
    # since all possible ages are from 0 to 8
    ages_helper = [0]*9
    for i in lines:
        ages_helper[i] += 1
    
    # each day number decreases by 1, 
    # if 0 adds new fish with age 8
    # also old fish continue from 6
    for each_day in range(rem_days):
        num_of_zeros = ages_helper[0]
        for i in range(len(ages_helper)-1):
            ages_helper[i] = ages_helper[i+1]
        ages_helper[6] = ages_helper[6] + num_of_zeros
        ages_helper[8] = num_of_zeros
    print(sum(ages_helper))

    

def solution(lines, rem_days):
    lines = [int(i) for i in lines]
    current_day = 0
    while current_day < rem_days:
        n = len(lines)
        current_day += 1
        for i in range(n):
            if lines[i] == 0:
                lines[i] = 6
                lines.append(8)
                continue
            lines[i] = lines[i] - 1
    
    print(len(lines))
            



if __name__ == '__main__':
    lines = open('../data/Day6Prob.txt','r').readlines()
    lines = lines[0].split(',')
    # solution(lines, 256)
    solution1(lines, 256)