// pages/edit/[id].tsx
import { useState, useEffect } from 'react'
import { useRouter } from 'next/router'

type Tenant = {
  id: string
  name: string
  createdAt: string
}

export default function EditTenant() {
  const router = useRouter()
  const { id } = router.query
  const [tenant, setTenant] = useState<Tenant | null>(null)
  const [name, setName] = useState('')
  const [message, setMessage] = useState('')

  useEffect(() => {
    if (!id) return
    fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/tenants/${id}`)
      .then((res) => res.json())
      .then((data) => {
        setTenant(data)
        setName(data.name)
      })
  }, [id])

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/tenants/${id}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ id, name }),
    })

    if (res.ok) {
      router.push('/')
    } else {
      const error = await res.text()
      setMessage(`Erreur : ${error}`)
    }
  }

  if (!tenant) return <p>Chargement...</p>

  return (
    <div style={{ padding: '2rem' }}>
      <h1>Modifier le tenant</h1>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
        <button type="submit">Enregistrer</button>
      </form>
      {message && <p style={{ marginTop: '1rem' }}>{message}</p>}
    </div>
  )
}
