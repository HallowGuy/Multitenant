// pages/index.tsx
import Link from 'next/link'

type Tenant = {
  id: string
  name: string
  createdAt: string
}

export async function getServerSideProps() {
  const res = await fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/tenants`)
  const tenants: Tenant[] = await res.json()
  return { props: { tenants } }
}

export default function TenantList({ tenants }: { tenants: Tenant[] }) {
  return (
    <div style={{ padding: '2rem' }}>
      <h1>Liste des tenants</h1>
      <ul>
        {tenants.map((tenant) => (
          <li key={tenant.id}>
            {tenant.name} – créé le {new Date(tenant.createdAt).toLocaleDateString()}
            {' '}|{' '}
            <Link href={`/edit/${tenant.id}`}>Modifier</Link>
          </li>
        ))}
      </ul>

      <hr />

      <Link href="/create">
        <button>Créer un nouveau tenant</button>
      </Link>
    </div>
  )
}
