# IT用語学習支援デスクトップアプリ（VocabLearningApp）
IT専門用語（基本情報技術者試験レベル等）の登録・検索・学習を支援するWindowsデスクトップアプリケーションです。

## 開発環境・技術スタック（Environment & Tech Stack）
* **言語・フレームワーク**: C# / .NET Framework 4.8
* **UIフレームワーク**: Windows Forms (WinForms) / DevExpress UI Controls
* **データベース**: Microsoft SQL Server (`VocabLearningDB`)
* **データアクセス**: ADO.NET
* **設計アーキテクチャ**: 3層アーキテクチャ（GUI / BUS / DAL）
* **開発ツール**: Visual Studio 2022 / SQL Server Management Studio (SSMS)

## システム構成（3層アーキテクチャ）
保守性と再利用性を高めるため、責務を3つの層に分離して実装しました。
* **GUI (Presentation Layer)**: DevExpressを用いた視認性・操作性の高い画面UIの構築
* **BUS (Business Logic Layer)**: 入力値のバリデーションや検索フィルタリング等の業務ロジック処理
* **DAL (Data Access Layer)**: ADO.NETを用いたSQL ServerへのCRUD処理およびパラメータ化クエリによるSQLインジェクション対策

## 主な機能（Features）
* IT用語の登録・編集・削除（CRUD機能）
* キーワードおよびカテゴリ別のリアルタイム検索・絞り込み機能
* 学習進捗・理解度管理機能

## 担当役割（My Role）
* チームリーダーとしてプロジェクト全体の進行管理・タスク設計を担当
* データベース設計（ER図作成・テーブル定義）およびDAL/BUS層のコアロジック実装
* DevExpressを用いた一覧表示・検索画面のUI実装

## セットアップ手順（Setup）
1. リポジトリをクローンします。
2. SQL Serverにて付属のSQLスクリプト（`VocabLearningDB.sql`）を実行し、データベースと初期データを構築します。
3. `VocabLearningApp/App.config` 内の `connectionStrings` をご自身のSQL Server環境に合わせて変更します。
4. `VocabLearningApp.sln` を Visual Studio 2022 で開き、NuGetパッケージを復元してビルド・実行します。

## 画面イメージ（Screenshots）
*(ここにアプリのメイン画面や検索画面のスクリーンショットを貼り付けてください)*
