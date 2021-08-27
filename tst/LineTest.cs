using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuplemetry;

namespace TuplemetryTester
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void Line_Collinear_Tests()
        {
            Assert.IsFalse(CJ.Collinear(AA), "Point A was incorrectly found to be collinear with point A");
            Assert.IsFalse(EE.Collinear(EE), "Point E was incorrectly found to be collinear with point E");
            Assert.IsFalse(OP.Collinear(new Line(J, J)), "Point J was incorrectly found to be collinear with point J");

            Assert.IsFalse(CJ.Collinear(OP), "Line O-P was incorrectly found to be collinear with line C-J");
            Assert.IsFalse(OP.Collinear(CJ), "Line C-J was incorrectly found to be collinear with line O-P");
            Assert.IsFalse(BH.Collinear(RS), "Line R-S was incorrectly found to be collinear with line B-H");
            Assert.IsFalse(CJ.Collinear(RS), "Line R-S was incorrectly found to be collinear with line C-J");
            Assert.IsFalse(RS.Collinear(UV), "Line U-V was incorrectly found to be collinear with line R-S");

            Assert.IsTrue(AB.Collinear(AB), "Line A-B was incorrectly found to not be collinear with line A-B");
            Assert.IsTrue(BA.Collinear(BA), "Line B-A was incorrectly found to not be collinear with line B-A");

            Assert.IsTrue(AC.Collinear(CD), "Line C-D was incorrectly found to not be collinear with line A-C");
            Assert.IsTrue(AC.Collinear(DC), "Line D-C was incorrectly found to not be collinear with line A-C");
            Assert.IsTrue(CA.Collinear(CD), "Line C-D was incorrectly found to not be collinear with line C-A");
            Assert.IsTrue(CA.Collinear(DC), "Line D-C was incorrectly found to not be collinear with line C-A");
            Assert.IsTrue(CD.Collinear(AC), "Line A-C was incorrectly found to not be collinear with line C-D");
            Assert.IsTrue(CD.Collinear(CA), "Line C-A was incorrectly found to not be collinear with line C-D");
            Assert.IsTrue(DC.Collinear(AC), "Line A-C was incorrectly found to not be collinear with line D-C");
            Assert.IsTrue(DC.Collinear(CA), "Line C-A was incorrectly found to not be collinear with line D-C");

            Assert.IsTrue(PF.Collinear(FP), "Line F-P was incorrectly found to not be collinear with line P-F");
            Assert.IsTrue(FP.Collinear(PF), "Line P-F was incorrectly found to not be collinear with line F-P");

            Assert.IsTrue(MB.Collinear(FG), "Line F-G was incorrectly found to not be collinear with line M-B");
            Assert.IsTrue(MB.Collinear(GF), "Line G-F was incorrectly found to not be collinear with line M-B");
            Assert.IsTrue(FG.Collinear(MB), "Line M-B was incorrectly found to not be collinear with line F-G");
            Assert.IsTrue(FG.Collinear(BM), "Line B-M was incorrectly found to not be collinear with line F-G");
            Assert.IsTrue(BM.Collinear(FG), "Line F-G was incorrectly found to not be collinear with line M-B");
            Assert.IsTrue(BM.Collinear(GF), "Line G-F was incorrectly found to not be collinear with line M-B");
            Assert.IsTrue(FG.Collinear(BM), "Line B-M was incorrectly found to not be collinear with line F-G");
            Assert.IsTrue(GF.Collinear(BM), "Line B-M was incorrectly found to not be collinear with line G-F");

            Assert.IsTrue(JT.Collinear(BV), "Line B-V was incorrectly found to not be collinear with line J-T");
            Assert.IsTrue(NL.Collinear(PQ), "Line N-L was incorrectly found to not be collinear with line P-Q");
            Assert.IsTrue(LN.Collinear(PQ), "Line L-N was incorrectly found to not be collinear with line P-Q");
        }

        [TestMethod]
        public void Line_Paralell_Tests()
        {
            Assert.IsFalse(AB.Parallel(BH), "Line A-B was incorrectly found to be parallel to line B-H");
            Assert.IsFalse(CJ.Parallel(RS), "Line C-J was incorrectly found to not be parallel to line R-S");

            Assert.IsTrue(AB.Parallel(AB), "Line A-B was incorrectly found to be not parallel to line A-B");
            Assert.IsTrue(AB.Parallel(CD), "Line C-D was incorrectly found to be not parallel to line A-B");
            Assert.IsTrue(BH.Parallel(RS), "Line R-S was incorrectly found to be not parallel to line B-H");
        }

        [TestMethod]
        public void Line_Perpendicular_Tests()
        {
            Assert.IsFalse(AB.Perpendicular(AB), "Line A-B was incorrectly found to be perpendicular to line A-B");
            Assert.IsFalse(AB.Perpendicular(CD), "Line C-D was incorrectly found to be perpendicular to line A-B");
            Assert.IsFalse(AB.Perpendicular(BH), "Line B-H was incorrectly found to be perpendicular to line A-B");
            Assert.IsFalse(IJ.Perpendicular(DE), "Line D-E was incorrectly found to be perpendicular to line I-J");
            Assert.IsFalse(DE.Perpendicular(IJ), "Line I-J was incorrectly found to be perpendicular to line D-E");

            Assert.IsTrue(BC.Perpendicular(BG), "Line B-G was incorrectly found to not be perpendicular to line B-C");
            Assert.IsTrue(BC.Perpendicular(FG), "Line F-G was incorrectly found to not be perpendicular to line B-C");
            Assert.IsTrue(CJ.Perpendicular(JK), "Line J-K was incorrectly found to not be perpendicular to line C-J");
            Assert.IsTrue(CJ.Perpendicular(LM), "Line L-M was incorrectly found to not be perpendicular to line C-J");
            Assert.IsTrue(LM.Perpendicular(CJ), "Line C-J was incorrectly found to not be perpendicular to line L-M");
            Assert.IsTrue(IJ.Perpendicular(OP), "Line O-P was incorrectly found to not be perpendicular to line I-J");
        }

        [TestMethod]
        public void Line_Intersects_Tests()
        {
            // Point intersection

            Assert.IsFalse(JV.Intersects(O), "Point O was incorrectly found to intersect line J-V");
            Assert.IsFalse(RS.Intersects(Q), "Point Q was incorrectly found to intersect line R-S");
            Assert.IsFalse(CJ.Intersects(M), "Point M was incorrectly found to intersect line C-J");

            Assert.IsTrue(AE.Intersects(C), "Point C was incorrectly found to not intersect line A-E");
            Assert.IsTrue(CD.Intersects(B), "Point B was incorrectly found to not intersect line C-D");
            Assert.IsTrue(FG.Intersects(B), "Point B was incorrectly found to not intersect line F-G");
            Assert.IsTrue(JV.Intersects(B), "Point B was incorrectly found to not intersect line J-V");
            Assert.IsTrue(JV.Intersects(U), "Point U was incorrectly found to not intersect line J-V");
            Assert.IsTrue(FP.Intersects(M), "Point M was incorrectly found to not intersect line F-P");

            // Line intersection

            Assert.IsFalse(RS.Intersects(UV), "Line U-V was incorrectly found to intersect line R-S");
            Assert.IsFalse(UV.Intersects(RS), "Line U-V was incorrectly found to intersect line U-V");

            Assert.IsTrue(AB.Intersects(AB), "Line A-B was incorrectly found to not intersect line A-B");

            Assert.IsTrue(AB.Intersects(CD), "Line C-D was incorrectly found to not intersect line A-B");
            Assert.IsTrue(CD.Intersects(AB), "Line A-B was incorrectly found to not intersect line C-D");

            Assert.IsTrue(AB.Intersects(AB), "Line A-B was incorrectly found to not intersect line A-B");
            Assert.IsTrue(AB.Intersects(BH), "Line A-B was incorrectly found to not intersect line B-H");

            Assert.IsTrue(OP.Intersects(CE), "Line C-E was incorrectly found to not intersect line O-P");
            Assert.IsTrue(CE.Intersects(OP), "Line O-P was incorrectly found to not intersect line C-E");

            Assert.IsTrue(CD.Intersects(BE), "Line B-E was incorrectly found to not intersect line C-D");
            Assert.IsTrue(BE.Intersects(CD), "Line C-D was incorrectly found to not intersect line B-E");

            Assert.IsTrue(BG.Intersects(BF), "Line B-F was incorrectly found to not intersect line B-G");
            Assert.IsTrue(BF.Intersects(BG), "Line B-G was incorrectly found to not intersect line B-F");

            Assert.IsTrue(BJ.Intersects(UV), "Line U-V was incorrectly found to not intersect line B-J");
            Assert.IsTrue(UV.Intersects(BJ), "Line B-J was incorrectly found to not intersect line U-V");

            Assert.IsTrue(LN.Intersects(LM), "Line L-M was incorrectly found to not intersect line L-N");
            Assert.IsTrue(LM.Intersects(LN), "Line L-N was incorrectly found to not intersect line L-M");

            Assert.IsTrue(LN.Intersects(LO), "Line L-O was incorrectly found to not intersect line L-N");
            Assert.IsTrue(LO.Intersects(LN), "Line L-N was incorrectly found to not intersect line L-O");

            Assert.IsTrue(LN.Intersects(KL), "Line K-L was incorrectly found to not intersect line L-N");
            Assert.IsTrue(KL.Intersects(LN), "Line L-N was incorrectly found to not intersect line K-L");

            Assert.IsTrue(NO.Intersects(LM), "Line L-M was incorrectly found to not intersect line N-O");
            Assert.IsTrue(LM.Intersects(NO), "Line N-O was incorrectly found to not intersect line L-M");

            Assert.IsTrue(NO.Intersects(LO), "Line L-O was incorrectly found to not intersect line N-O");
            Assert.IsTrue(LO.Intersects(NO), "Line N-O was incorrectly found to not intersect line L-O");

            Assert.IsTrue(NO.Intersects(KL), "Line K-L was incorrectly found to not intersect line N-O");
            Assert.IsTrue(KL.Intersects(NO), "Line N-O was incorrectly found to not intersect line K-L");

            Assert.IsTrue(NQ.Intersects(IM), "Line I-M was incorrectly found to not intersect line N-Q");

            Assert.IsTrue(JL.Intersects(IM), "Line I-M was incorrectly found to not intersect line J-L");
            Assert.IsTrue(IM.Intersects(JL), "Line J-L was incorrectly found to not intersect line I-M");

            Assert.IsTrue(HT.Intersects(IM), "Line I-M was incorrectly found to not intersect line H-T");
            Assert.IsTrue(IM.Intersects(HT), "Line H-T was incorrectly found to not intersect line I-M");

            Assert.IsTrue(BT.Intersects(HV), "Line H-V was incorrectly found to not intersect line B-T");
            Assert.IsTrue(HV.Intersects(BT), "Line B-T was incorrectly found to not intersect line H-V");

            Assert.IsTrue(HT.Intersects(UV), "Line U-V was incorrectly found to not intersect line H-T");
            Assert.IsTrue(UV.Intersects(HT), "Line H-T was incorrectly found to not intersect line U-V");

            Assert.IsTrue(HT.Intersects(BH), "Line B-H was incorrectly found to not intersect line H-T");
            Assert.IsTrue(BH.Intersects(HT), "Line H-T was incorrectly found to not intersect line B-H");

            Assert.IsTrue(NO.Intersects(DE), "Line D-E was incorrectly found to not intersect line N-O");
            Assert.IsTrue(NO.Intersects(ED), "Line E-D was incorrectly found to not intersect line N-O");
            Assert.IsTrue(DE.Intersects(NO), "Line N-O was incorrectly found to not intersect line D-E");
            Assert.IsTrue(ED.Intersects(NO), "Line N-O was incorrectly found to not intersect line E-D");
            Assert.IsTrue(ON.Intersects(DE), "Line D-E was incorrectly found to not intersect line O-N");
            Assert.IsTrue(ON.Intersects(ED), "Line E-D was incorrectly found to not intersect line O-N");
            Assert.IsTrue(DE.Intersects(ON), "Line O-N was incorrectly found to not intersect line D-E");
            Assert.IsTrue(ED.Intersects(ON), "Line O-N was incorrectly found to not intersect line E-D");
        }

        [TestMethod]
        public void LineSegment_Intersection_Tests()
        {
            LineSegment Result;

            Result = AB.Intersection(AB);
            Assert.IsNotNull(Result, "Line A-B was incorrectly found to not intersect A-B");
            Assert.IsTrue(new LineSegment(A, B) == Result, "Line A-B was incorrectly found to intersect A-B at: " + Result);

            Result = AB.Intersection(CD);
            Assert.IsNotNull(Result, "Line C-D was incorrectly found to not intersect A-B at: " + Result);
            Assert.IsTrue(new LineSegment(A, D) == Result, "Line C-D was incorrectly found to intersect A-B at: " + Result);

            Result = AB.Intersection(BH);
            Assert.IsNotNull(Result, "Line B-H was incorrectly found to not intersect A-B");
            Assert.IsTrue(new LineSegment(B, B) == Result, "Line B-H was incorrectly found to intersect A-B at: " + Result);

            Result = AC.Intersection(AB);
            Assert.IsNotNull(Result, "Line A-B was incorrectly found to not intersect A-C");
            Assert.IsTrue(new LineSegment(C, A) == Result, "Line A-B was incorrectly found to intersect A-C at: " + Result);

            Result = AC.Intersection(EC);
            Assert.IsNotNull(Result, "Line E-C was incorrectly found to not intersect A-C");
            Assert.IsTrue(new LineSegment(A, E) == Result, "Line C-E was incorrectly found to intersect C-A at: " + Result);

            Result = AC.Intersection(CE);
            Assert.IsNotNull(Result, "Line C-E was incorrectly found to not intersect A-C");
            Assert.IsTrue(new LineSegment(A, E) == Result, "Line C-E was incorrectly found to intersect C-A at: " + Result);

            Result = CA.Intersection(EC);
            Assert.IsNotNull(Result, "Line E-C was incorrectly found to not intersect C-A");
            Assert.IsTrue(new LineSegment(A, E) == Result, "Line C-E was incorrectly found to intersect C-A at: " + Result);

            Result = CA.Intersection(CE);
            Assert.IsNotNull(Result, "Line C-E was incorrectly found to not intersect C-A");
            Assert.IsTrue(new LineSegment(A, E) == Result, "Line C-E was incorrectly found to intersect C-A at: " + Result);

            Result = AC.Intersection(ED);
            Assert.IsNotNull(Result, "Line E-D was incorrectly found to not intersect A-C at: " + Result);
            Assert.IsTrue(new LineSegment(A, E) == Result, "Line E-D was incorrectly found to intersect A-C at: " + Result);

            Result = AC.Intersection(DE);
            Assert.IsNotNull(Result, "Line D-E was incorrectly found to not intersect A-C at: " + Result);
            Assert.IsTrue(new LineSegment(E, A) == Result, "Line D-E was incorrectly found to intersect A-C at: " + Result);

            Result = CA.Intersection(ED);
            Assert.IsNotNull(Result, "Line E-D was incorrectly found to not intersect C-A at: " + Result);
            Assert.IsTrue(new LineSegment(A, E) == Result, "Line D-E was incorrectly found to intersect A-C at: " + Result);

            Result = CA.Intersection(DE);
            Assert.IsNotNull(Result, "Line D-E was incorrectly found to not intersect C-A at: " + Result);
            Assert.IsTrue(new LineSegment(E, A) == Result, "Line D-E was incorrectly found to intersect A-C at: " + Result);

            Result = FG.Intersection(BF);
            Assert.IsNotNull(Result, "Line B-F was incorrectly found to not intersect F-G");
            Assert.IsTrue(new LineSegment(F, B) == Result, "Line B-F was incorrectly found to intersect F-G at: " + Result);

            Result = BF.Intersection(FG);
            Assert.IsNotNull(Result, "Line F-G was incorrectly found to not intersect B-F");
            Assert.IsTrue(new LineSegment(F, B) == Result, "Line F-G was incorrectly found to intersect B-F at: " + Result);

            Result = BG.Intersection(BF);
            Assert.IsNotNull(Result, "Line B-F was incorrectly found to not intersect B-G");
            Assert.IsTrue(new LineSegment(F, B) == Result, "Line B-F was incorrectly found to intersect B-G at: " + Result);

            Result = BF.Intersection(BG);
            Assert.IsNotNull(Result, "Line B-G was incorrectly found to not intersect B-F");
            Assert.IsTrue(new LineSegment(B, F) == Result, "Line B-G was incorrectly found to intersect B-F at: " + Result);

            Result = BG.Intersection(FG);
            Assert.IsNotNull(Result, "Line F-G was incorrectly found to not intersect B-G");
            Assert.IsTrue(new LineSegment(B, F) == Result, "Line F-G was incorrectly found to intersect B-G at: " + Result);

            Result = FG.Intersection(BG);
            Assert.IsNotNull(Result, "Line B-G was incorrectly found to not intersect B-F");
            Assert.IsTrue(new LineSegment(F, B) == Result, "Line B-G was incorrectly found to intersect B-F at: " + Result);

            Result = BM.Intersection(MB);
            Assert.IsNotNull(Result, "Line M-B was incorrectly found to not intersect B-M");
            Assert.IsTrue(new LineSegment(M, B) == Result, "Line M-B was incorrectly found to intersect B-M at: " + Result);

            Result = MB.Intersection(BM);
            Assert.IsNotNull(Result, "Line B-M was incorrectly found to not intersect M-B");
            Assert.IsTrue(new LineSegment(M, B) == Result, "Line M-B was incorrectly found to intersect B-M at: " + Result);

            Result = PF.Intersection(FB);
            Assert.IsNotNull(Result, "Line F-B was incorrectly found to not intersect P-F");
            Assert.IsTrue(new LineSegment(P, B) == Result, "Line F-B was incorrectly found to intersect P-F at: " + Result);

            Result = PM.Intersection(GF);
            Assert.IsNotNull(Result, "Line G-F was incorrectly found to intersect P-M at: " + Result);
            Assert.IsTrue(new LineSegment(M, G) == Result, "Line G-F was incorrectly found to intersect P-M at: " + Result);

            Result = HT.Intersection(UV);
            Assert.IsNotNull(Result, "Line U-V was incorrectly found to not intersect H-T");
            Assert.IsTrue(new LineSegment(H, T) == Result, "Line U-V was incorrectly found to intersect H-T at: " + Result);

            Result = UV.Intersection(HT);
            Assert.IsNotNull(Result, "Line H-T was incorrectly found to not intersect U-V");
            Assert.IsTrue(new LineSegment(H, T) == Result, "Line H-T was incorrectly found to intersect U-V at: " + Result);

            Result = IJ.Intersection(IL);
            Assert.IsNotNull(Result, "Line I-L was incorrectly found to not intersect I-J");
            Assert.IsTrue(new LineSegment(L, I) == Result, "Line I-L was incorrectly found to intersect I-J at: " + Result);

            Result = IL.Intersection(IJ);
            Assert.IsNotNull(Result, "Line I-J was incorrectly found to not intersect I-L");
            Assert.IsTrue(new LineSegment(I, L) == Result, "Line I-J was incorrectly found to intersect I-L at: " + Result);

            Result = IL.Intersection(JK);
            Assert.IsNotNull(Result, "Line J-K was incorrectly found to not intersect I-L");
            Assert.IsTrue(new LineSegment(I, L) == Result, "Line J-K was incorrectly found to intersect I-L at: " + Result);

            Result = JK.Intersection(IL);
            Assert.IsNotNull(Result, "Line I-L was incorrectly found to not intersect J-K");
            Assert.IsTrue(new LineSegment(I, L) == Result, "Line J-K was incorrectly found to intersect I-L at: " + Result);

            Result = JL.Intersection(IK);
            Assert.IsNotNull(Result, "Line I-K was incorrectly found to not intersect J-L");
            Assert.IsTrue(new LineSegment(I, L) == Result, "Line J-K was incorrectly found to intersect I-L at: " + Result);

            Result = IK.Intersection(JL);
            Assert.IsNotNull(Result, "Line J-L was incorrectly found to not intersect I-K");
            Assert.IsTrue(new LineSegment(I, L) == Result, "Line J-K was incorrectly found to intersect I-L at: " + Result);

            Result = KM.Intersection(NO);
            Assert.IsNotNull(Result, "Line N-O was incorrectly found to not intersect K-M");
            Assert.IsTrue(new LineSegment(L, L) == Result, "Line K-M was incorrectly found to intersect N-O at: " + Result);

            Result = new Line(M, D).Intersection(new Line(N, C));
            Assert.IsNotNull(Result, "Line N-C was incorrectly found to intersect M-D at: " + Result);
            Assert.IsTrue(new LineSegment(new Coordinate(-1.818182f, 4.909091f), new Coordinate(-1.818182f, 4.909091f)) == Result, "Line N-C was incorrectly found to intersect M-D at: " + Result);

            Result = CJ.Intersection(BJ);
            Assert.IsNotNull(Result, "Line B-J was incorrectly found to intersect C-J at: " + Result);
            Assert.IsTrue(new LineSegment(J, J) == Result, "Line B-J was incorrectly found to intersect C-J at: " + Result);

            Result = new Line(RS.Intersection(DC).A, Q).Intersection(KL);
            Assert.IsNull(Result, "Line D-x-E was incorrectly found to intersect on R-S at: " + Result);

            Result = RS.Intersection(new Line(J, J));
            Assert.IsNull(Result, "Point J was incorrectly found to occur on R-S at: " + Result);

            Result = CJ.Intersection(LQ);
            Assert.IsNull(Result, "Line L-Q was incorrectly found to intersect C-J at: " + Result);

            Result = RS.Intersection(BU);
            Assert.IsNull(Result, "Line B-U was incorrectly found to intersect R-S at: " + Result);

            Result = new Line(V, C).Intersection(BG);
            Assert.IsNull(Result, "Line B-G was incorrectly found to intersect C-V at: " + Result);
        }

        [TestMethod]
        public void Line_Member_Tests()
        {
            LineSegment Intersection;

            Assert.IsTrue(Segments.Length == SegmentNames.Length, "(" + Segments.Length + ") Line segments but (" + SegmentNames.Length + ") Line Segment names");

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\LineMemberTests.txt");

            int ab = 0;

            foreach (Line AB in Segments)
            {
                int cd = 0;

                foreach (Line CD in Segments)
                {
                    file.WriteLine((SegmentNames[ab] + AB).PadRight(40) + (SegmentNames[cd] + CD).PadLeft(40));
                    file.WriteLine("".PadLeft(80, '-'));

                    file.Write(("Parallel:".PadRight(18) + Line.Parallel(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.Write(("Collinear:".PadRight(18) + Line.Collinear(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));
                    file.WriteLine("Perpendicular:".PadRight(18) + Line.Perpendicular(AB.A, AB.B, CD.A, CD.B).ToString());
                    file.Write(("Intersects:".PadRight(18) + Line.Intersects(AB.A, AB.B, CD.A, CD.B).ToString()).PadRight(40));

                    Intersection = AB.Intersection(CD);

                    file.WriteLine("Intersection:".PadRight(18) + (null == Intersection ? "{null}" : Intersection.ToString()));
                    file.WriteLine(" ");

                    cd++;
                }

                ab++;
            }

            file.Close();
        }

        static Coordinate A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V;

        static Line AA, AB, AC, AD, AE, BA, BB, BC, BD, BE, BF, BG, BH, BJ, BM, BP, BT, BU, BV, CA, CB, CC, CD, CE, CJ, DA, DB, DC, DD, DE, EA, EB, EC, ED, EE, FB, FF, FG, FM, FP, GB, GF, GM, GP, HJ, HT, HU, HV, IJ, IK, IL, IM, JK, JL, JT, JU, JV, KL, KM, LM, LN, LO, LP, LQ, MB, MF, MG, MP, NL, NO, NP, NQ, ON, OP, OQ, PB, PF, PG, PM, PQ, RS, TU, TV, UV;

        static Line[] Segments;

        string[] SegmentNames = { "AA", "AB", "AC", "AD", "AE", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BJ", "BM", "BP", "BT", "BU", "BV", "CA", "CB", "CC", "CD", "CE", "CJ", "DA", "DB", "DC", "DD", "DE", "EA", "EB", "EC", "ED", "EE", "FB", "FF", "FG", "FM", "FP", "GB", "GF", "GM", "GP", "HJ", "HT", "HU", "HV", "IJ", "IK", "IL", "IM", "JK", "JL", "JT", "JU", "JV", "KL", "KM", "LM", "LN", "LO", "LP", "LQ", "MB", "MF", "MG", "MP", "NL", "NO", "NP", "NQ", "ON", "OP", "OQ", "PB", "PF", "PG", "PM", "PQ", "RS", "TU", "TV", "UV" };

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            A = new Coordinate(14, 17);
            B = new Coordinate(14, 12);
            C = new Coordinate(14, 6);
            D = new Coordinate(14, -3);
            E = new Coordinate(14, -12);
            F = new Coordinate(4, 12);
            G = new Coordinate(8, 12);
            H = new Coordinate(17, 15);
            I = new Coordinate(0, -12);
            J = new Coordinate(-4, -6);
            K = new Coordinate(-8, 0);
            L = new Coordinate(-12, 6);
            M = new Coordinate(-16, 12);
            N = new Coordinate(-15, 4);
            O = new Coordinate(-9, 8);
            P = new Coordinate(-3, 12);
            Q = new Coordinate(0, 14);
            R = new Coordinate(9, -12);
            S = new Coordinate(5, -16);
            T = new Coordinate(-14, -16);
            U = new Coordinate(2, 0);
            V = new Coordinate(8, 6);

            AA = new Line(A, A);
            AB = new Line(A, B);
            AC = new Line(A, C);
            AD = new Line(A, D);
            AE = new Line(A, E);
            BA = new Line(B, A);
            BB = new Line(B, B);
            BC = new Line(B, C);
            BD = new Line(B, D);
            BE = new Line(B, E);
            BF = new Line(B, F);
            BG = new Line(B, G);
            BH = new Line(B, H);
            BJ = new Line(B, J);
            BM = new Line(B, M);
            BP = new Line(B, P);
            BT = new Line(B, T);
            BU = new Line(B, U);
            BV = new Line(B, V);
            CA = new Line(C, A);
            CB = new Line(C, B);
            CC = new Line(C, C);
            CD = new Line(C, D);
            CE = new Line(C, E);
            CJ = new Line(C, J);
            DA = new Line(D, A);
            DB = new Line(D, B);
            DC = new Line(D, C);
            DD = new Line(D, D);
            DE = new Line(D, E);
            EA = new Line(E, A);
            EB = new Line(E, B);
            EC = new Line(E, C);
            ED = new Line(E, D);
            EE = new Line(E, E);
            FB = new Line(F, B);
            FG = new Line(F, G);
            FF = new Line(F, F);
            FM = new Line(F, M);
            FP = new Line(F, P);
            GB = new Line(G, B);
            GF = new Line(G, F);
            GM = new Line(G, M);
            GP = new Line(G, P);
            HJ = new Line(H, J);
            HT = new Line(H, T);
            HU = new Line(H, U);
            HV = new Line(H, V);
            IJ = new Line(I, J);
            IK = new Line(I, K);
            IL = new Line(I, L);
            IM = new Line(I, M);
            JK = new Line(J, K);
            JL = new Line(J, L);
            JT = new Line(J, T);
            JU = new Line(J, U);
            JV = new Line(J, V);
            KL = new Line(K, L);
            KM = new Line(K, M);
            LM = new Line(L, M);
            LN = new Line(L, N);
            LO = new Line(L, O);
            LP = new Line(L, P);
            LQ = new Line(L, Q);
            MB = new Line(M, B);
            MF = new Line(M, F);
            MG = new Line(M, G);
            MP = new Line(M, P);
            NL = new Line(N, L);
            NO = new Line(N, O);
            NP = new Line(N, P);
            NQ = new Line(N, Q);
            ON = new Line(O, N);
            OP = new Line(O, P);
            OQ = new Line(O, Q);
            PB = new Line(P, B);
            PF = new Line(P, F);
            PG = new Line(P, G);
            PM = new Line(P, M);
            PQ = new Line(P, Q);
            PM = new Line(P, M);
            RS = new Line(R, S);
            TU = new Line(T, U);
            TV = new Line(T, V);
            UV = new Line(U, V);

            Segments = new Line[] { AA, AB, AC, AD, AE, BA, BB, BC, BD, BE, BF, BG, BH, BJ, BM, BP, BT, BU, BV, CA, CB, CC, CD, CE, CJ, DA, DB, DC, DD, DE, EA, EB, EC, ED, EE, FB, FF, FG, FM, FP, GB, GF, GM, GP, HJ, HT, HU, HV, IJ, IK, IL, IM, JK, JL, JT, JU, JV, KL, KM, LM, LN, LO, LP, LQ, MB, MF, MG, MP, NL, NO, NP, NQ, ON, OP, OQ, PB, PF, PG, PM, PQ, RS, TU, TV, UV };
        }
    }
}
