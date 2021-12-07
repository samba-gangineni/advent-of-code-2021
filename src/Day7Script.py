def solution(lines):
    max_val, min_val = max(lines), min(lines)
    total = float('inf')
    for i in range(min_val, max_val+1):
        current_cost = 0
        for each_pos in lines:
            current_cost += abs(i-each_pos)
        if current_cost < total:
            total = current_cost
    print(total)

def solution1(lines):
    max_val, min_val = max(lines), min(lines)
    total = float('inf')
    for i in range(min_val, max_val+1):
        current_cost = 0
        for each_pos in lines:
            diff = abs(i-each_pos)
            current_cost += diff*(diff+1)/2
        if current_cost < total:
            total = current_cost
    print(total)



if __name__ == '__main__':
    lines = open('../data/Day7Prob.txt','r').readlines()
    lines = [int(x) for x in lines[0].split(',')]
    solution(lines)
    solution1(lines)