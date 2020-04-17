# 競技プログラミング用ライブラリ

## The Repository

C#用の競技プログラミングライブラリです

- まだまだ不完全だし、不具合もありそう

## How to use in a contest

解答の仕方

- Program.cs内のSolveメソッドへに解答を記入してください
  - 入力、出力用のメソッドはProgramクラスの継承元のBaseProgramに存在します
- Program.cs内に存在しないアルゴリズムは必要に応じて他からProgram.csへコピペしてください
- 問題を解けたら、Program.csのコード全てを解答入力フォームへ丸コピしてください

自動コードテストの仕方

- 設問の入力をInput*.txtへコピペしてください
- 設問の出力をInput*.txtへコピペしてください
- Visual Studioであれば、表示 > テストエクスプローラからテストエクスプローラを開き、実行をクリックしてください

## Contributing

devブランチへのプルリク歓迎です
git慣れていないのでバージョン管理回りで変なところあれば教えてほしいです...(切実)

- ファイル構成
  - 拡張メソッド系はProgram.cs
  - それ以外のstaticメソッド系はLibrary/OtherAlgorisms.cs
  - UnionFind的な大規模なものはLibrary/直下に新規ファイルで追加してほしいです
  - テストコードは実装の方のフォルダ構成を真似てください
- 出来ればテストコード書いてね
