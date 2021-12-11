def solution1(lines):
    nrows = len(lines)
    ncols = len(lines[0])
    step = 1
    while step:
        flash_stack = []
        visited_flash = set()
        # iterating over rows and columns
        for row in range(nrows):
            for col in range(ncols):
                # for each value increment it's value and push the element into stack if it's value is greater than 8
                lines[row][col] += 1
                if lines[row][col] > 9: 
                    flash_stack.append((row,col))
                    visited_flash.add((row, col))
        while len(flash_stack):
            # Get the row about to flash
            (flash_row, flash_col) = flash_stack.pop()
            lines[flash_row][flash_col] = 0
            # Get all 8 possibilites
            up = flash_row - 1
            down = flash_row + 1
            left = flash_col - 1
            right = flash_col + 1
            # Element above the current element
            if up >=0 and up < nrows and (up, flash_col) not in visited_flash:
                lines[up][flash_col] += 1
                if lines[up][flash_col] > 9:
                    flash_stack.append((up,flash_col))
                    visited_flash.add((up, flash_col))
            # Element below the current element
            if down >=0 and down < nrows and (down, flash_col) not in visited_flash:
                lines[down][flash_col] += 1
                if lines[down][flash_col] > 9:
                    flash_stack.append((down,flash_col))
                    visited_flash.add((down, flash_col))
            # Element left of the current element
            if left >=0 and left < ncols and (flash_row, left) not in visited_flash:
                lines[flash_row][left] += 1
                if lines[flash_row][left] > 9:
                    flash_stack.append((flash_row,left))
                    visited_flash.add((flash_row, left))
            # Element right of the current element
            if right >=0 and right < ncols and (flash_row, right) not in visited_flash:
                lines[flash_row][right] += 1
                if lines[flash_row][right] > 9:
                    flash_stack.append((flash_row,right))
                    visited_flash.add((flash_row, right))
            ### Diagonals
            # Element top-left the current element
            if up >=0 and up < nrows and left >=0 and left < ncols and (up, left) not in visited_flash:
                lines[up][left] += 1
                if lines[up][left] > 9:
                    flash_stack.append((up,left))
                    visited_flash.add((up, left))
            # Element down-left of the current element
            if down >=0 and down < nrows and left >=0 and left < ncols and (down, left) not in visited_flash:
                lines[down][left] += 1
                if lines[down][left] > 9:
                    flash_stack.append((down,left))
                    visited_flash.add((down, left))
            # Element top-right of the current element
            if up >=0 and up < nrows and right >=0 and right < ncols and (up, right) not in visited_flash:
                lines[up][right] += 1
                if lines[up][right] > 9:
                    flash_stack.append((up,right))
                    visited_flash.add((up, right))
            # Element down-right of the current element
            if down >=0 and down < nrows and right >=0 and right < ncols and (down, right) not in visited_flash:
                lines[down][right] += 1
                if lines[down][right] > 9:
                    flash_stack.append((down,right))
                    visited_flash.add((down, right))
        if sum([sum(i) for i in lines]) == 0:
            print(f'{step}: syncs here')
            return
        step += 1
    for i in lines:
        print(i)

def solution(lines, steps):
    nrows = len(lines)
    ncols = len(lines[0])
    flashes = 0
    for step in range(steps):
        flash_stack = []
        visited_flash = set()
        # iterating over rows and columns
        for row in range(nrows):
            for col in range(ncols):
                # for each value increment it's value and push the element into stack if it's value is greater than 8
                lines[row][col] += 1
                if lines[row][col] > 9: 
                    flash_stack.append((row,col))
                    visited_flash.add((row, col))
        while len(flash_stack):
            # Get the row about to flash
            (flash_row, flash_col) = flash_stack.pop()
            lines[flash_row][flash_col] = 0
            flashes += 1
            # Get all 8 possibilites
            up = flash_row - 1
            down = flash_row + 1
            left = flash_col - 1
            right = flash_col + 1
            # Element above the current element
            if up >=0 and up < nrows and (up, flash_col) not in visited_flash:
                lines[up][flash_col] += 1
                if lines[up][flash_col] > 9:
                    flash_stack.append((up,flash_col))
                    visited_flash.add((up, flash_col))
            # Element below the current element
            if down >=0 and down < nrows and (down, flash_col) not in visited_flash:
                lines[down][flash_col] += 1
                if lines[down][flash_col] > 9:
                    flash_stack.append((down,flash_col))
                    visited_flash.add((down, flash_col))
            # Element left of the current element
            if left >=0 and left < ncols and (flash_row, left) not in visited_flash:
                lines[flash_row][left] += 1
                if lines[flash_row][left] > 9:
                    flash_stack.append((flash_row,left))
                    visited_flash.add((flash_row, left))
            # Element right of the current element
            if right >=0 and right < ncols and (flash_row, right) not in visited_flash:
                lines[flash_row][right] += 1
                if lines[flash_row][right] > 9:
                    flash_stack.append((flash_row,right))
                    visited_flash.add((flash_row, right))
            ### Diagonals
            # Element top-left the current element
            if up >=0 and up < nrows and left >=0 and left < ncols and (up, left) not in visited_flash:
                lines[up][left] += 1
                if lines[up][left] > 9:
                    flash_stack.append((up,left))
                    visited_flash.add((up, left))
            # Element down-left of the current element
            if down >=0 and down < nrows and left >=0 and left < ncols and (down, left) not in visited_flash:
                lines[down][left] += 1
                if lines[down][left] > 9:
                    flash_stack.append((down,left))
                    visited_flash.add((down, left))
            # Element top-right of the current element
            if up >=0 and up < nrows and right >=0 and right < ncols and (up, right) not in visited_flash:
                lines[up][right] += 1
                if lines[up][right] > 9:
                    flash_stack.append((up,right))
                    visited_flash.add((up, right))
            # Element down-right of the current element
            if down >=0 and down < nrows and right >=0 and right < ncols and (down, right) not in visited_flash:
                lines[down][right] += 1
                if lines[down][right] > 9:
                    flash_stack.append((down,right))
                    visited_flash.add((down, right))

    print(flashes)
    for i in lines:
        print(i)

if __name__=='__main__':
    lines = open('../data/Day11Prob.txt', 'r').readlines()
    lines = [[int(j) for j in line.strip()] for line in lines]
    solution(lines,100)
    solution1(lines)