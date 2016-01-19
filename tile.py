#A greedy algorithm for tiling an area with the 
#least number of rectangles
# 0: open
# 1: wall
#2+: the different rectangles

randomShape = [[1,1,1,1,1,1,1],
		       [1,0,0,0,0,0,1],
		       [1,0,0,0,0,1,1],
		       [1,0,0,1,0,0,1],
		       [1,0,0,0,0,0,1],
		       [1,0,1,0,0,0,1],
		       [1,1,1,1,1,1,1]]
	 
yShape = [[1,1,1,1,1,1,1],
          [1,0,1,1,1,0,1],
          [1,0,1,1,1,0,1],
          [1,0,1,1,1,0,1],
          [1,0,0,0,0,0,1],
          [1,1,1,0,1,1,1],
          [1,1,1,1,1,1,1]]	 
	 
plusShape = [[1,1,1,1,1,1,1],
             [1,1,1,0,1,1,1],
             [1,1,1,0,1,1,1],
	         [1,0,0,0,0,0,1],
	         [1,1,1,0,1,1,1],
             [1,1,1,0,1,1,1],
             [1,1,1,1,1,1,1]]	 

#find the tallest rectangle that will fit
#given its base
#x,y is one side of the base
#r is the length of the base
def tallest(grid, x, y, r):
	t = y
	good = True
	while good:
		for i in range(x,r+1):
			if grid[i][t] != 0:
				good = False
		if good:
			t = t + 1
	return t-1

#find the biggest rectangle that will fit
#coordinates x,y is the "top, left" corner
def biggest(grid,x, y):
	maxSize = 0
	maxR = x
	maxT = y
	
	r = x
	t = y
	
	while grid[r][y] == 0:
		t = tallest(grid, x,y,r)
		if (r-x+1)*(t-y+1) > maxSize:
			maxR = r
			maxT = t
			maxSize = (r-x+1)*(t-y+1)
		r = r+1
	return maxR, maxT

#fills in a rectangle in the grid with value
def fillIn(grid, x,y,r,t,value):
	for i in range(x,r+1):
		for j in range(y,t+1):
			grid[i][j] = value

#for every empty square in the grid find the biggest
#rectangle that will fit
def tile(grid):
	value = 2
	for x in range(0,7):
		for y in range(0,7):
			if grid[x][y] == 0:
				r, t = biggest(grid, x,y)
				fillIn(grid, x,y,r,t,value)
				value = value + 1
	for row in grid:
		print(row)
		
tile(plusShape)
print()
tile(randomShape)
print()
tile(yShape)