"""

"""
segments_digits_dict = {
    '12': '1',
    '012': '7',
    '1256': '4',
    '01346': '2',
    '01236': '3',
    '02356': '5',
    '023456': '6',
    '012345': '0',
    '012356': '9',
    '0123456': '8'
}

def solution1(lines):
    lines = [i.strip().split('|') for i in lines]
    count = 0
    for each_line in lines:
        order = get_order(each_line[0].strip().split())
        order = {order[i]:i for i in range(7)}
        count += get_four_digits(order, each_line[1].strip().split())
    print(count)


def get_order(patterns):
    unique_digit_patterns = sorted([i for i in patterns if len(i) < 5 or len(i) > 6 ], key=lambda x: len(x))
    five_segment_patterns = [i for i in patterns if len(i)==5 ]
    # order of checking numbers 1, 7 , 4 , 8
    order = ['']*7
    for each_pattern in unique_digit_patterns:
        if len(each_pattern) == 2:
            # these postions needed to be swapped at the end
            order[1] = each_pattern[0]
            order[2] = each_pattern[1]
        elif len(each_pattern) == 3:
            for each_char in each_pattern:
                if each_char not in order:
                    order[0] = each_char # this position is fixed
        elif len(each_pattern) == 4:
            index = 5
            for each_char in each_pattern:
                if each_char not in order:
                    order[index] = each_char # this position needs to be swapped
                    index += 1
        elif len(each_pattern) == 7:
            index = 3
            for each_char in each_pattern:
                if each_char not in order:
                    order[index] = each_char # this position needs to be swapped
                    index += 1

    # select pattern representing 3 i.e., 3 contains 1
    for each_pattern in five_segment_patterns:
        # condition to check for number 3
        if order[1] in each_pattern and order[2] in each_pattern:
            # fix remaining two characters
            for each_char in each_pattern:
                if each_char not in order[:3]:
                    # fixing position of this char to '3'
                    if each_char in order[3:5] and each_char == order[4]:
                        order[3], order[4] = order[4], order[3]
                    # fixing position of this char to '6'
                    if each_char in order[5:7] and each_char == order[5]:
                        order[5], order[6] = order[6], order[5]
    # represents number 2 '01346'
    number_2 = sorted(order[0]+order[1]+order[3]+order[4]+order[6])
    all_set = False
    for each_pattern in [sorted(i) for i in five_segment_patterns]:
        if number_2 == each_pattern:
            all_set = True
    
    if not all_set:
        order[1], order[2] = order[2], order[1]
    # print(order)
    return order

def get_four_digits(order, output):
    count = []
    for each_digit in output:
        digits = []
        for each_char in each_digit:
            digits.append(order[each_char])
        digits.sort()
        count.append(segments_digits_dict[''.join([str(i) for i in digits])])
    return int(''.join(count))


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
    # solution(lines)
    solution1(lines)