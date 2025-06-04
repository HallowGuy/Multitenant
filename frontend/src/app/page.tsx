import Tile from '../components/Tile'

export default function HomePage() {
  return (
    <div className="grid grid-cols-2 md:grid-cols-4 gap-4 mt-4">
      <Tile
        href="/dashboard"
        size="large"
        className="bg-secondary text-white col-span-2 row-span-2 shadow-lg"
      >
        <div>
          <h2 className="text-2xl font-semibold">Tableau de bord</h2>
          <p className="text-sm mt-2">Accéder à vos données</p>
        </div>
      </Tile>
      <Tile href="/profil" className="bg-primary text-white shadow-md">
        Mon profil
      </Tile>
      <Tile href="/docs" className="bg-black text-white shadow-md">
        Documentation
      </Tile>
      <Tile href="/support" className="bg-white text-black border shadow-md">
        Support
      </Tile>
    </div>
  )
}
