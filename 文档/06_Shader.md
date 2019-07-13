
<script type="text/javascript"
       src="http://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-AMS-MML_HTMLorMML"></script>
## 01 渲染流水

 ![渲染流水](./06/01.png)

 **Cpu应用阶段：**
 ![cpu应用阶段](./06/02.png)

**几何阶段以及光栅化应用阶段：**
 ![几何阶段和光栅化阶段](./06/03.png)

 **顶点着色器:**

 &ensp;顶点着色器的处理单位是顶点

 &ensp;主要工作：坐标变换以及逐顶点光照，输出后续阶段需要的数据

 &ensp;模型空间 -->齐次裁剪空间-->计算顶点颜色

 &ensp;0.vertex = UnityObjectToClipPos(v.vertex); //unity 2017及以上

**裁剪：**
 ![裁剪](./06/04.png)

**屏幕映射:**
 ![屏幕映射](./06/05.png)

 **三角形设置和三角形遍历：**

 **片元着色器与逐片元操作：**

 **模版测试和深度测试：**

 **合并混合：**


## 02 UnityShader

**shaderLab的基本类型：**

**1. 顶点片元shader:**
![shaderLab属性的基本类型](./06/06.png)

**2. sufrfaceShader:**


## 3 数学知识

**二维：**

**三维：**

**矩阵：**
1. 简答的矩阵：
    $$
    \left\{
        \begin{matrix}
        7 & 8 & 20 & 9\\
        9 & 45 & 6 & 0\\
        3 & 4 & 6 & 67
        \end{matrix}
    \right\}
    $$

2. 对角矩阵与单位矩阵
    * 方阵： 行数=列数
    $$
        \left\{
        \begin{matrix}
        m11 & m12 & m13\\
        m21 & m22 & m23\\
        m31 & m32 & m33
        \end{matrix}
        \right\}
    $$ 
    * 对角矩阵： 方阵对角线以外全为**0**
    $$
        \left\{
            \begin{matrix}
            5 & 0 & 0\\
            0 & 8 & 0\\
            0 & 0 & 7
            \end{matrix}
            \right\}
    $$
    * 单位矩阵： 对角线全为**1**，非对角线全为**0**
    $$
    \left\{
        \begin{matrix}
        1 & 0 & 0 & 0\\
        0 & 1 & 0 & 0\\
        0 & 0 & 1 & 0\\
        0 & 0 & 0 & 1
        \end{matrix}
    \right\}
    $$

3. 矩阵与向量
    * 列向量
    $$
    \left[
    \begin{matrix}
    5\\
    6\\
    7
    \end{matrix}
    \right]
    $$
    * 行向量
    $$
    \left[
        \begin{matrix}
        6 & 7 & 8
        \end{matrix}
        \right
    ]
    $$

4. 矩阵的转置以及标量乘法
    * 矩阵的转置：
    $$
        \left[
            \begin{matrix}
            5 & 4 & 3\\
            7 & 8 & 9
            \end{matrix}
            \right]
            ^T 
        = 
        \left[
            \begin{matrix}
            5 & 7 \\
            4 & 8 \\
            3 & 9 
            \end{matrix}
            \right]
    $$
>可知行向量的转置是列向量，列向量的转置是行向量
且  $(M^T)^T = M$ 且对角矩阵 $D^T = D$


5. 标量与矩阵的乘法：
$$
KM = K
\left[
    \begin{matrix}
    m11 & m12 & m13\\
    m21 & m22 & m23\\
    m31 & m32 & m33
    \end{matrix}
    \right]
=
\left[
    \begin{matrix}
    K*m11 & K*m12 & K*m13\\
    K*m21 & K*m22 & K*m23\\
    K*m31 & K*m32 & K*m33
    \end{matrix}
    \right]
$$

6. 矩阵的乘法：
    * 矩阵的乘法需要满足 $r*n$ 阶矩阵， 与之相乘的需要为 $n*c$ 阶矩阵， 结果为 $r*c$ 阶矩阵 即需要满足
    前一个矩阵的列等于下一个矩阵的行
    $$
    \left[
        \begin{matrix}
        a11 & a12 \\
        a21 & a22\\
        a31 & a32\\
        a41 & a42
        \end{matrix}
    \right]
        *
    \left[
        \begin{matrix}
        b11 & b12 & b13 & b14\\
        b21 & b22 & b23 & b24
        \end{matrix}
    \right]
     = 
    \left[
        \begin{matrix}
        c11 & c12 & c13 & c14\\
        c21 & c22 & c23 & c24\\
        c31 & c32 & c33 & c34\\
        c41 & c42 & c43 & c44
        \end{matrix}
        \right]
    $$
    其中C中单个的位置的值
    $$
        C_{ij} = \sum_{k=1}^c a_{ik}b_{kj}
    $$

7. 项目中遇到的主要是 （2 x 2 ） （  3 x 3） （  4 x 4）

8. 矩阵乘法的特点： 
* $MI = M$ 即矩阵乘单位矩阵，任然等于自己
* $AB \neq BA$
* $(AB)C = A(BC)$
* $(kA)B = k(AB) = A(kB)$
* $(AB)^T = B^TA^T$

8. 向量矩阵相乘

9. 矩阵向量转换





