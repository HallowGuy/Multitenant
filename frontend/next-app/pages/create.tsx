// pages/create.tsx
import { useState } from 'react'
import { useRouter } from 'next/router'

export default function CreateTenant() {
  const [name, setName] = useState('')
  const [message, setMessage] = useState('')
  const router = useRouter()

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/tenants`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ name }),
    })

    if (res.ok) {
      router.push('/')
    } else {
      const error = await res.text()
      setMessage(`Erreur : ${error}`)
    }
  }

  return (
    <div style={{ padding: '2rem' }}>
      <h1>Créer un nouveau tenant</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Nom du tenant"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
        <button type="submit">Créer</button>
      </form>
      {message && <p style={{ marginTop: '1rem' }}>{message}</p>}
    </div>
  )
}
