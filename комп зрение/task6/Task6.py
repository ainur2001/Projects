import math

import numpy as np
from PIL import Image
import matplotlib.pyplot as plt


def toGray(image):
  original = np.array(image)
  data = np.array(original)
  height, width, _ = data.shape
  gray_image = np.zeros((height, width), dtype=int)
  for i in range(height):
      for j in range(width):
          gray_image[i, j] = np.sum(data[i, j]) / 3
  return gray_image


def descriptor(img):
    original = np.array(img)
    data = np.array(original)
    height, width = data.shape[0], data.shape[1]

    gray_image = toGray(img)

    t = 30
    intensity = np.zeros((4), dtype=int)
    special = []
    num = 1
    num1 = 0
    num2 = 0

    circle = [[3, 0], [3, 1], [2, 2], [1, 3], [0, 3], [-1, 3], [-2, 2], [-3, 1], [-3, 0], [-3, -1], [-2, -2],
              [-1, -3], [0, -3], [1, -3], [2, -2], [3, -1]]


    for i in range(3, height - 3):
        for j in range(3, width - 3):
            intensity[0] = gray_image[i, j + 3]
            intensity[1] = gray_image[i + 3, j]
            intensity[2] = gray_image[i, j - 3]
            intensity[3] = gray_image[i - 3, j]
            a = gray_image[i, j]
            num1 = 0
            num2 = 0
            for b in intensity:
                if a >= b + t:
                    num1 += 1
                if b >= a + t:
                    num2 += 1
            if num1 < 3 and num2 < 3:
                continue
            num1, num2 = 0, 0
            for k in range(-9, len(circle)):
                b = gray_image[i + circle[k][0], j + circle[k][1]]
                if a >= b + t:
                    num1 += 1
                    if num1 > 9:
                        special.append([i, j])
                        break
                else:
                    num1 = 0
                if b >= a + t:
                    num2 += 1
                    if num2 > 9:
                        special.append([i, j])
                        break
                else:
                    num2 = 0



    filter_size = (5, 5)
    filter_center = (2, 2)
    filter = np.zeros(filter_size, dtype=float)
    sigma = 1
    c = 1 / (2 * np.pi * sigma * sigma)
    for i in range(5):
        for j in range(5):
            filter[i, j] = c * np.exp(-((j - 2) ** 2 + (i - 2) ** 2) / (2 * sigma * sigma))
    k = 0
    for i in range(5):
        for j in range(5):
            k += filter[i, j]
    for i in range(5):
        for j in range(5):
            filter[i, j] /= k

    afterfilter = np.zeros((gray_image.shape[0] + filter_center[0] * 2,
                            gray_image.shape[1] + filter_center[1] * 2))
    org = np.array(afterfilter.astype(np.uint8))
    org[filter_center[0]: -filter_center[0], filter_center[1]:-filter_center[1]] = gray_image
    for i in range(height):
        for j in range(width):
            afterfilter[i + filter_center[0], j + filter_center[1]] = \
                np.sum(org[i: i + filter_size[0], j: j + filter_size[1]] * filter)
    afterfilter = afterfilter[filter_center[0]: -filter_center[0], filter_center[1]:-filter_center[1]]
    blur = afterfilter


    filter_x = np.zeros((3, 3), dtype=int)
    filter_x[0] = [-1, 0, 1]
    filter_x[1] = [-2, 0, 2]
    filter_x[2] = [-1, 0, 1]
    filter_y = np.zeros((3, 3), dtype=int)
    filter_y[0] = [-1, -2, -1]
    filter_y[1] = [0, 0, 0]
    filter_y[2] = [1, 2, 1]
    aftersobel = np.zeros((height, width), dtype=int)
    afterfilter2 = np.zeros((gray_image.shape[0] + 2, gray_image.shape[1] + 2))
    for i in range(1, afterfilter2.shape[0] - 1):
        for j in range(1, afterfilter2.shape[1] - 1):
            afterfilter2[i, j] = afterfilter[i - 1, j - 1]
    for i in range(1, afterfilter2.shape[0] - 1):
        for j in range(1, afterfilter2.shape[1] - 1):
            for k in range(3):
                for m in range(3):
                    aftersobel[i - 1, j - 1] += afterfilter2[i + k - 1, j + m - 1] * filter_x[k, m]
    aftersobelx = aftersobel / 8
    aftersobelx /= np.max(aftersobelx) / 255

    for i in range(1, afterfilter2.shape[0] - 1):
        for j in range(1, afterfilter2.shape[1] - 1):
            for k in range(3):
                for m in range(3):
                    aftersobel[i - 1, j - 1] += afterfilter2[i + k - 1, j + m - 1] * filter_y[k, m]
    aftersobely = aftersobel / 8
    aftersobely /= np.max(aftersobely) / 255


    aftersobel = aftersobelx ** 2 + aftersobely ** 2
    aftersobel = np.sqrt(aftersobel)
    magnitude = aftersobel
    magnitude = magnitude.astype(np.uint8)


    Rs = []
    center = filter.shape[0] // 2
    k = 0.04
    ix2 = aftersobelx ** 2
    ixiy = aftersobelx * aftersobely
    iy2 = aftersobely ** 2
    for l in range(len(special)):

        y = special[l][0] - center
        x = special[l][1] - center

        m = np.zeros((2, 2))
        for u in range(filter.shape[0]):
            for v in range(filter.shape[1]):
                if y + u < aftersobelx.shape[0] and x + v < aftersobelx.shape[1]:
                    a = np.array([[ix2[y + u, x + v], ixiy[y + u, x + v]],
                                  [ixiy[y + u, x + v], iy2[y + u, x + v]]])
                    m += filter[u, v] * a
        R = np.linalg.det(m) - k * np.trace(m) ** 2
        if R > 0:
            Rs.append([R, l])
    Rs = sorted(Rs, key=lambda Rs: Rs[0], reverse=True)
    R_sorted = Rs[:700]

    special2 = []

    k = 0
    for i in R_sorted:
        special2.append([special[i[1]][0], special[i[1]][1]])
        original[special[i[1]][0], special[i[1]][1]] = [255, 0, 0]
        original[special[i[1]][0] + 1, special[i[1]][1]] = [255, 0, 0]
        original[special[i[1]][0] - 1, special[i[1]][1]] = [255, 0, 0]
        original[special[i[1]][0], special[i[1]][1] + 1] = [255, 0, 0]
        original[special[i[1]][0], special[i[1]][1] - 1] = [255, 0, 0]
        k += 1
    plt.imshow(original)
    plt.show()


    radius = 31
    m10 = 0
    m01 = 0
    angles = []
    for i in R_sorted:
        x, y = special[i[1]][0], special[i[1]][1]
        for k in range(-radius, radius):
            for l in range(-radius, radius):
                if (k ** 2 + l ** 2 < radius ** 2):
                    if 0 < x + k < gray_image.shape[0] and 0 < y + l < gray_image.shape[1]:
                        m10 += l * gray_image[x + k, y + l]
                        m01 += k * gray_image[x + k, y + l]
        angles.append([x, y, round(math.atan2(m01, m10) / (np.pi / 15)) * (np.pi / 15)])
        m10 = 0
        m01 = 0



    l = 0
    lines = []
    for i in R_sorted:
        line = np.zeros((256), dtype=int)
        num = 0
        angle = angles[l][2]
        l += 1
        rotation = np.array([[np.cos(angle), -np.sin(angle)], [np.sin(angle), np.cos(angle)]])
        points = (rotation @ p.T).astype(int).T
        points2 = (rotation @ p2.T).astype(int).T
        for k in range(len(points)):
            if 0 < special[i[1]][0] + points[k][0] < gray_image.shape[0] and 0 < \
                    special[i[1]][1] + points[k][1] < gray_image.shape[1] and 0 < \
                    special[i[1]][0] + points2[k][0] < gray_image.shape[0] and 0 < \
                    special[i[1]][1] + points2[k][1] < gray_image.shape[1]:
                if blur[special[i[1]][0] + points[k][0], special[i[1]][1] + points[k][1]] < \
                        blur[special[i[1]][0] + points2[k][0], special[i[1]][1] + points2[k][1]]:
                    line[num] = 1
                else:
                    line[num] = 0
                num += 1
        lines.append(line)
    return lines, angles, special2



def hamming(vector1, vector2):
    d = 0
    for i in range(len(vector1)):
        if vector1[i] != vector2[i]:
            d += 1
    return d


def test_lowe(vector, vectors1, vectors2):
    ind_min1, ind_min2 = -1, -1
    min1, min2 = np.inf, np.inf
    for i in range(len(vectors1)):
        d = hamming(vector, vectors1[i])
        if min1 == np.inf:
            min1 = d
            ind_min1 = i
        elif d < min1:
            min2 = min1
            min1 = d
            ind_min2 = ind_min1
            ind_min1 = i
        elif min1 <= d < min2:
            min2 = d
            ind_min2 = i

    for i in range(len(vectors2)):
        d = hamming(vector, vectors2[i])
        if min1 == np.inf:
            min1 = d
            ind_min1 = i + len(vectors1)
        elif d < min1:
            min2 = min1
            min1 = d
            ind_min2 = ind_min1
            ind_min1 = i + len(vectors1)
        elif min1 <= d < min2:
            min2 = d
            ind_min2 = i + len(vectors1)
    return [ind_min1, ind_min2, min1/min2 if min2 != 0 else 0]



if __name__ == "__main__":
    image = np.array(Image.open('box.png').convert("RGB"))
    scene = np.array(Image.open('box_in_scene.png').convert("RGB"))

    image_arr = Image.open('box.png').convert("RGB")
    scene_arr = Image.open('box_in_scene.png').convert("RGB")

    
    p = []
    p2 = []
    for num in range(256):
        k = np.random.normal(0, 31/5)
        l = np.random.normal(0, 31/5)
        n = np.random.normal(0, 31/5)
        m = np.random.normal(0, 31/5)

        p.append([k, l])
        p2.append([n, m])

    p = np.array(p)
    p2 = np.array(p2)

    vectors, angles, special = descriptor(image_arr)
    width, height = image_arr.width, image_arr.height
    width //= 2
    height //= 2
    image_small = image_arr.resize((width, height))
    vectors2, angles2, special2 = descriptor(image_small)

    vectors_scene, angles_scene, special_scene = descriptor(scene)
    width_scene, height_scene = scene_arr.width, scene_arr.height
    width_scene //= 2
    height_scene //= 2
    scene_small = scene_arr.resize((width_scene, height_scene))
    vectors_scene2, angles_scene2, special_scene2 = descriptor(scene_small)



    Rs = []
    match_point = []
    v = 0
    for vector in vectors:
        R = test_lowe(vector, vectors_scene, vectors_scene2)
        if R[2] < 0.8:
            Rs.append(R)
            match_point.append([special[v][0], special[v][1]])
        v += 1

    v = 0
    for vector in vectors2:
        R = test_lowe(vector, vectors_scene, vectors_scene2)
        if R[2] < 0.8:
            Rs.append(R)
            match_point.append([special2[v][0]*2, special2[v][1]*2])
        v += 1

    img_scene_copy = np.array(scene)

    match_scene_point = []

    for i in Rs:
        if i[0] < len(special_scene):
            match_scene_point.append(special_scene[i[0]])
        else:
            match_scene_point.append([special_scene2[i[0] - len(special_scene)][0] * 2,
                                    special_scene2[i[0] - len(special_scene)][1] * 2])

    for i in match_scene_point:
        img_scene_copy[i[0], i[1]] = 255, 0, 0
        img_scene_copy[i[0] + 1, i[1]] = 255, 0, 0
        img_scene_copy[i[0] - 1, i[1]] = 255, 0, 0
        img_scene_copy[i[0], i[1] - 1] = 255, 0, 0
        img_scene_copy[i[0], i[1] + 1] = 255, 0, 0

    plt.imshow(img_scene_copy)
    plt.show()

    img_copy = np.array(image)

    for i in match_point:
        img_copy[i[0], i[1]] = 255, 0, 0
        img_copy[i[0] + 1, i[1]] = 255, 0, 0
        img_copy[i[0] - 1, i[1]] = 255, 0, 0
        img_copy[i[0], i[1] - 1] = 255, 0, 0
        img_copy[i[0], i[1] + 1] = 255, 0, 0

    plt.imshow(img_copy)
    plt.show()

    # не-выбросы
    max_inliers = 0
    inliers = None
    inliers_ind = None
    match = np.array(match_point)
    match_scene = np.array(match_scene_point)
    match2 = np.ones((match.shape[0], match.shape[1]+1))
    match2[:, :2] = match
    match_scene2 = np.ones((match_scene.shape[0], match_scene.shape[1] + 1))
    match_scene2[:, :2] = match_scene

    for i in range(800):
        ind = np.random.randint(0, len(match), 3)
        before = [[match[i][0], match[i][1], 1] for i in ind]
        after = [[match_scene[i][0], match_scene[i][1], 1] for i in ind]
        before = np.array(before)
        after = np.array(after)
        b = after.flatten()
        # матрица для СЛАУ
        A = np.zeros((9, 9))
        for i in range(3):
            offset = 0
            for k in range(3):
                for j in range(3):
                    A[i*3 + k, j+offset] = before[i][j]
                offset += 3
        if np.linalg.det(A) == 0:
            continue
        x = np.linalg.solve(A, b)
        
        # матрица перспективного преобразования 
        H = x.reshape((3, 3))
        after2 = (H @ match2.T).T
        dist = np.sqrt(np.sum((after2 - match_scene2)**2, axis=1))
        inliers_count = np.count_nonzero(dist < 3)
        if inliers_count > max_inliers:
            inliers_ind = np.argwhere(dist < 3)
            max_inliers = inliers_count
            inliers = match2[dist < 3], match_scene2[dist < 3]

    

    A2 = np.zeros((inliers[1].shape[0]*3, 9))
    for i in range(inliers[1].shape[0]):
        offset = 0
        for k in range(3):
            for j in range(3):
                A2[i*3 + k, j+offset] = inliers[0][i][j]
            offset += 3
    b2 = inliers[1].flatten()
    x_approx = np.linalg.pinv(A2) @ b2
    H = x_approx.reshape((3, 3))
    inliers_match = inliers[0].astype(np.int64)
    inliers_match_scene = inliers[1].astype(np.int64)

    af = ((H @ inliers_match.T).T).astype(np.int64)

    image_copy = np.array(image)
    image_scene_copy = np.array(scene)
    concat_img = np.zeros((max(image_copy.shape[0], image_scene_copy.shape[0]),
                        image_copy.shape[1]+image_scene_copy.shape[1], 3), dtype=np.uint8)
    concat_img[:image_copy.shape[0], :image_copy.shape[1]] = image_copy
    concat_img[:image_scene_copy.shape[0], image_copy.shape[1]:] = image_scene_copy
    width = image_copy.shape[1]

    polygon = np.array([[0, 0, 1], [0, image_copy.shape[1], 1],
                        [image_copy.shape[0], image_copy.shape[1], 1], [image_copy.shape[0], 0, 1]])
    new_polygon = (H @ polygon.T).T
    plt.imshow(concat_img)

    for i in inliers_ind:
        p1, p2 = match_point[i[0]], match_scene_point[i[0]]
        plt.plot([p1[1], p2[1]+width], [p1[0], p2[0]])
    for i in range(new_polygon.shape[0]):
        plt.plot([polygon[i-1, 1], polygon[i, 1]],
                [polygon[i-1, 0], polygon[i, 0]], c='red')

        plt.plot([new_polygon[i-1, 1]+width, new_polygon[i, 1]+width],
                [new_polygon[i-1, 0], new_polygon[i, 0]], c='pink')
    plt.show()