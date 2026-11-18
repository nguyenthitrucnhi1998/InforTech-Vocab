# IT用語学習支援デスクトップアプリ（VocabLearningApp）

IT専門用語（基本情報技術者試験・応用情報技術者試験レベル等）の登録・検索・学習を支援するWindowsデスクトップアプリケーションです。

---

## 開発環境・技術スタック（Environment & Tech Stack）

* **言語・フレームワーク**: C# / .NET Framework 4.8
* **UIフレームワーク**: Windows Forms (WinForms) / DevExpress UI Controls
* **データベース**: Microsoft SQL Server (`VocabLearningDB`)
* **データアクセス**: ADO.NET
* **設計アーキテクチャ**: 3層アーキテクチャ（GUI / BUS / DAL）
* **開発ツール**: Visual Studio 2022 / SQL Server Management Studio (SSMS)

---

## システム構成（3層アーキテクチャ）

保守性と再利用性を高めるため、責務を3つの層に分離して実装しました。

* **GUI (Presentation Layer)**: DevExpressを用いた視認性・操作性の高い画面UIの構築
* **BUS (Business Logic Layer)**: 入力値のバリデーションや検索フィルタリング等の業務ロジック処理
* **DAL (Data Access Layer)**: ADO.NETを用いたSQL ServerへのCRUD処理およびパラメータ化クエリによるSQLインジェクション対策

---

## 主な機能（Features）

* IT用語の登録・編集・削除（CRUD機能）
* キーワードおよびカテゴリ別のリアルタイム検索・絞り込み機能
* フラッシュカードおよび4択クイズによる学習・復習機能

---

## 担当役割（My Role）

* チームリーダーとしてプロジェクト全体の進行管理・タスク設計を担当
* データベース設計（ER図作成・テーブル定義）およびDAL/BUS層のコアロジック実装
* DevExpressを用いた一覧表示・検索画面のUI実装

---

## セットアップ手順（Setup）

1. リポジトリをクローンします。
2. SQL Serverにて付属のSQLスクリプト（`VocabLearningDB.sql`）を実行し、データベースと初期データを構築します。
3. `VocabLearningApp/App.config` 内の `connectionStrings` をご自身のSQL Server環境に合わせて変更します。
4. `VocabLearningApp.sln` を Visual Studio 2022 で開き、NuGetパッケージを復元してビルド・実行します。

---

## 画面イメージ（Screenshots）

### 1. 用語登録・管理画面（メイン画面）
IT資格試験（基本情報技術者試験など）の学習や専門用語の整理を目的としたデスクトップアプリケーションのメイン画面です。  
左ペインのデータリストから目的の用語を素早く検索・選択でき、右ペインでは「用語名」「ふりがな」「意味」の基本情報に加え、具体的な計算例などのメタデータや説明用画像を紐づけて登録・編集することが可能です。

<img width="1913" height="938" alt="image" src="https://github.com/user-attachments/assets/2bbbf612-6af6-440f-99b8-210f708c4f22" />

### 2. 用語登録・管理画面（比較表・図解の併用イメージ）
用語「基数（radix）」の登録・閲覧イメージです。  
画面右下の「追加情報」セクションでは、左側の「メタデータ（View）」にHTML形式の比較表（進数変換対応表など）を表示しつつ、右側の「画像」エリアに具体的な計算プロセスの図解を並べて配置できます。複雑なIT基礎理論も、表データと図解の両面から分かりやすく整理・管理できる設計となっています。

<img width="1919" height="1016" alt="image" src="https://github.com/user-attachments/assets/7b6d3c80-c17d-4d54-917f-17a780c2bbd8" />

### 3. 辞書画面（IT用語一覧・検索）
登録されたIT用語を辞書形式で閲覧・検索できる画面です。  
上部の「FE」「AP」ボタンによる試験区分ごとのデータ切り替えに対応しているほか、カテゴリ階層による絞り込みやキーワード検索を組み合わせて目的の用語に素早くアクセスできます。また、一覧の操作列から各用語の詳細モーダル表示や、苦手用語をまとめる「保存リスト」への追加をワンクリックで実行できます。

<img width="1919" height="1015" alt="image" src="https://github.com/user-attachments/assets/907a60c8-0924-44b1-9b6b-1d1e5ae7d7c3" />

### 4. 用語詳細画面（モーダルダイアログ）
辞書一覧から選択した用語の詳細情報を確認するためのサブウィンドウです。  
「用語パス」によって大分類から小分類までの位置づけを明確に把握できるほか、テキストによる補足説明（メタデータ）と解説画像を同時に確認できるため、複雑な概念や計算アルゴリズムも直感的に学習できます。また、ツールバーの「保存リスト選択」から任意の単語帳リストへワンクリックで追加できます。

<img width="1919" height="1016" alt="image" src="https://github.com/user-attachments/assets/a47e8134-b47e-40d8-b981-0e16d3c2c4ff" />

### 5. 復習画面 ＆ フラッシュカード学習モード
登録したIT用語を効率よく定着させるための復習モードです。  
メイン画面のツリーリストで復習対象のカテゴリをチェックボックスで選択し、「復習スタート」を押すとフラッシュカード形式の学習ダイアログが起動します。カードの表面には「用語名・ふりがな」、裏面には「語義（説明文）」が表示され、カード反転や前後移動のボタンを使ってテンポよく暗記学習を進めることができます。

<img width="1919" height="1014" alt="image" src="https://github.com/user-attachments/assets/f6835424-758e-45e2-bc9b-975b594ffda1" />
<img width="1919" height="1018" alt="image" src="https://github.com/user-attachments/assets/a3bfbfa2-a5fa-4a63-b783-ad4233d6c98d" />

### 6. クイズモード（4択問題による理解度テスト）
フラッシュカードで覚えた用語の定着度を確認できる4択クイズ画面です。  
画面上部に用語の説明文（質問）が出題され、下部のラジオボタン（A〜D）から該当する用語を選択して解答します。解答の確定（正誤判定）や選択のリセット、前後の問題への移動が下部のコントロールバーから直感的に操作できるよう設計されています。

<img width="1919" height="1020" alt="image" src="https://github.com/user-attachments/assets/c1f493df-bfe7-4e3f-a822-95b594ffda1" />
