// src/app/layout.tsx
import './globals.css'
import type { Metadata } from 'next'

export const metadata: Metadata = {
  title: 'MoonSite Multitenant',
  description: 'Gestion Multitenant – Projet Hadi',
}

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="fr">
      <body className="bg-white text-black">
        <header className="w-full p-4 border-b border-gray-200 text-center font-bold text-xl">Muntitenant</header>
        <main className="min-h-screen px-8 py-4">{children}</main>
        <footer className="w-full p-4 border-t border-gray-200 text-center text-sm text-gray-600">Muntitenant</footer>
      </body>
    </html>
  )
}
