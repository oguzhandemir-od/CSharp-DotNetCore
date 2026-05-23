import math

points = [(1, 2), (3, 5), (7, 8), (2, 4), (5, 7)]

def euclideanDistance(point1,point2)
    x1,y1=point1
    x2, y2 = point2
    return math.sqrt((x2 - x1)**2 + (y2 - y1)**2)

distances[]

for i in range(len(points)):
    for j in range(i + 1, len(points)):
        distance = euclideanDistance(points[i], points[j])
        distances.append(distance)

for pair in point_pairs:
    point1, point2, distance = pair
    print(f"Mesafe {point1} ve {point2} arasında: {distance}")

min_distance = min(distances)
print(f"Minimum mesafe: {min_distance}")
