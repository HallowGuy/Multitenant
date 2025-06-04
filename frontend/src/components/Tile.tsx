import Link from 'next/link'

interface TileProps {
  href?: string
  size?: 'small' | 'medium' | 'large'
  className?: string
  children: React.ReactNode
}

export default function Tile({ href, size = 'medium', className = '', children }: TileProps) {
  const sizeClass = size === 'large' ? 'tile-large' : size === 'small' ? 'tile-small' : 'tile-medium'
  const classes = `tile ${sizeClass} ${className}`.trim()

  if (href) {
    return (
      <Link href={href} className={classes}>
        {children}
      </Link>
    )
  }

  return <div className={classes}>{children}</div>
}
