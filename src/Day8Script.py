def solution(lines):
    lines = [i.strip().split('|')[1].strip().split() for i in lines]
    count = 0
    for each_line in lines:
        for each_digit in each_line:
            if len(each_digit) in [2, 3, 4, 7]:
                count += 1
    print(count)

if __name__=='__main__':
    lines = open('../data/Day8Prob.txt', 'r').readlines()
    solution(lines)